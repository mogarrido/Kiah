using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avispa : Enemy
{
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
    
    
    [SerializeField]
    float sleepTime = 2f;
    [SerializeField]
    float patrolTime = 5f;
    float patrolTimer = 0f;
    float sleepTimer = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        actualCoroutine = IdleCoroutine(sleepTime, "patrol");
        StartCoroutine(IdleCoroutine(sleepTime, "patrol"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Die)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("die");
                DeleteFromScene();
            }
            return;
        }
        if(CanAttack && !isAttacking)
        {
            lastFlip = spr.flipX;
            StartCoroutine(AttackCoroutine("attack", attackClip, actualCoroutine));
            StopCoroutine(actualCoroutine);
        }
        if(isAttacking && CanAttack)
        {
            spr.flipX = RightRay ? false : LeftRay ? true : spr.flipX;
        } 
    }
    bool CanAttack => Physics2D.OverlapCircle(transform.position, areaRadius, areaDetectionLayer);

    void OnDrawGizmosSelected()
    {
        Gizmos.color = areaColor;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.right * rayDistance);
        Gizmos.DrawRay(transform.position, Vector2.left * rayDistance);
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
        anim.SetBool(stateName, true);
        spr.flipX = !spr.flipX;
        direction = new Vector2(-direction.x, direction.y);
        while(true)
        {
            if (Die)
            {
                break;
            }
            patrolTimer += Time.deltaTime;
            if(patrolTimer >= duration)
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

    void MakeDamageToPlayer()
    {
        GameManager.instance.GetPlayer.RecivingDamage(damage);
        GameManager.instance.GetHealthBar.SetValue(GameManager.instance.GetPlayer.GetHealth);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!isMakingDamage)
        {
            isMakingDamage = true;
            MakeDamageToPlayer();
        }
    }

    bool RightRay => Physics2D.Raycast(transform.position, Vector2.right, rayDistance, detectionLayer);
    bool LeftRay => Physics2D.Raycast(transform.position, Vector2.left, rayDistance, detectionLayer);
    bool Die => health == 0;
}
