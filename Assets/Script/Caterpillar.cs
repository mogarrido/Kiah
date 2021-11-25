using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : Enemy
{
    [SerializeField]
    float sleepTime = 2f;
    [SerializeField]
    float patrolTime = 5f;
    float patrolTimer = 0f;
    float sleepTimer = 0f;

    //Attack area
    [SerializeField, Range(0.1f, 20f)]
    float areaRadius = 5f;
    [SerializeField]
    Color areaColor = Color.red;
    [SerializeField]
    LayerMask areaDetectionLayer;
    IEnumerator actualCoroutine;

   [SerializeField]
    Collider2D headcolliderLeft;
    [SerializeField]
    Collider2D headcolliderRight;

     //Raycast things
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField]
    LayerMask detectionLayer;

    
     public OrugaAttackSound OrugaAttackSound;
     [SerializeField]
     float AttackingSoundDelay = 2f;
     bool canPlayAttackingSound = true; 
    
    public OrugaWalkSound OrugaWalkSound;
    [SerializeField]
    float WalkingSoundDelay = 2f;
    bool canPlayWalkingSound = true; 


    void Start()
    {
        actualCoroutine = IdleCoroutine(sleepTime, "patrol");
        StartCoroutine(IdleCoroutine(sleepTime, "patrol"));
    }
    
   
    void Update()
    {
        if (Die)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("die");
            }
            return;
        }
        if(CanAttack && !isAttacking)
        {
            lastFlip = spr.flipX;
            StartCoroutine(AttackCoroutine("attack", attackClip, actualCoroutine));
            canPlayAttackingSound = true; 
            StartCoroutine(PlayOrugaAttacking());
            
            StopCoroutine(actualCoroutine);
        }
        if(isAttacking && CanAttack)
        {
            spr.flipX = RightRay ? false : LeftRay ? true : spr.flipX;
            

        }
        
    }

    public override IEnumerator IdleCoroutine(float duration, string stateName)
    {
        anim.SetBool(stateName, false);
        while(true)
        {
            sleepTimer += Time.deltaTime;
            if(sleepTimer >= duration)
            {
                sleepTimer = 0f;
                actualCoroutine = MovementCoroutine(patrolTime, "patrol");
                StartCoroutine(actualCoroutine);
                break;
            }
            yield return null;
        }
    }

    public override IEnumerator MovementCoroutine(float duration, string stateName)
    {
        canPlayWalkingSound = true; 
        anim.SetBool(stateName, true);
        spr.flipX = !spr.flipX;
        direction = new Vector2(-direction.x, direction.y);
        while(true)
        {
            patrolTimer += Time.deltaTime;
            if (canPlayWalkingSound)
            {
                canPlayWalkingSound = false; 
                StartCoroutine(PlayWalkingSound());
            }
          
            if(patrolTimer >= duration )
            {
                patrolTimer = 0f;
                actualCoroutine = IdleCoroutine(sleepTime, "patrol");
                
                StartCoroutine(actualCoroutine);
                break;
            }
         transform.Translate(direction * moveSpeed * Time.deltaTime);    
         yield return null; 
         
        }

       
       
        
    }
     IEnumerator PlayOrugaAttacking() 
    {
        OrugaAttackSound.AttackingOruga();
        yield return new WaitForSeconds(AttackingSoundDelay);
        canPlayAttackingSound = true;
    }
    IEnumerator PlayWalkingSound()
    {
        OrugaWalkSound.WalkingOruga();
        yield return new WaitForSeconds(WalkingSoundDelay);
        canPlayWalkingSound = true; 
    }
  



    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = areaColor;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.right * rayDistance);
        Gizmos.DrawRay(transform.position, Vector2.left * rayDistance);
    }

    bool CanAttack => Physics2D.OverlapCircle(transform.position, areaRadius, areaDetectionLayer);

    void MakeDamageToPlayer()
    {
        GameManager.instance.GetPlayer.RecivingDamage(damage);
        GameManager.instance.GetHealthBar.SetValue(GameManager.instance.GetPlayer.GetHealth);
    }

    void ActivateCollider()
    {
        if(spr.flipX)
        {
            headcolliderLeft.enabled = true;
            headcolliderRight.enabled = false;
        }
        else
        {
            headcolliderLeft.enabled = false;
            headcolliderRight.enabled = true;
        }
    }

    void DesableCollider()
    {
        headcolliderLeft.enabled = false;
        headcolliderRight.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!isMakingDamage)
        {
            isMakingDamage = true;
            MakeDamageToPlayer();
        }
    }

    void LateUpdate()
    {
        //anim.SetBool("detection", Detection); 
    }

    

    bool RightRay => Physics2D.Raycast(transform.position, Vector2.right, rayDistance, detectionLayer);
    bool LeftRay => Physics2D.Raycast(transform.position, Vector2.left, rayDistance, detectionLayer);
    bool Die => health == 0;
    bool IsWalking => Grounding;
     bool Grounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, detectionLayer);
}
