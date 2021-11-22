using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avispa : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public bool chase = false; 
    public Transform startingPoint; 
   
    
    
<<<<<<< Updated upstream
     
=======
    [SerializeField]
    public AvispaIdle AvispaIdle; 
    float idleSoundDelay = 2f; 
    bool canPlayAvispaIdle = true; 
    [SerializeField]
    public AvispaAttackSound AvispaAttackSound; 
    float attackavispaDelay = 2f; 
    bool canPlayAvispaAttackSound = true; 

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if(player == null)
           return; 
        if (chase==true)
           return; 
=======
        if (Die)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("die");
                DeleteFromScene();
                canPlayAvispaIdle = false; 
            }
            return;
        }
        if(CanAttack && !isAttacking)
        {
            lastFlip = spr.flipX;
            StartCoroutine(AttackCoroutine("attack", attackClip, actualCoroutine));
            StopCoroutine(actualCoroutine);
            canPlayAvispaAttackSound = false; 
            StartCoroutine(PlayattackingSound());
        }
        if(isAttacking && CanAttack)
        {
            spr.flipX = RightRay ? false : LeftRay ? true : spr.flipX;
        } 
    }
    bool CanAttack => Physics2D.OverlapCircle(transform.position, areaRadius, areaDetectionLayer);
>>>>>>> Stashed changes

           
        else 
           //go to starting point
           ReturnStartPosition(); 
           Flip (); 

<<<<<<< Updated upstream
=======
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
        
>>>>>>> Stashed changes
    }

    private void Chase ()
    {
<<<<<<< Updated upstream
        transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed * Time.deltaTime); 
=======
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

        if (canPlayAvispaIdle)
        {
            canPlayAvispaIdle = true; 
            StartCoroutine(PlayavispaIdleSound());
        }
        
>>>>>>> Stashed changes
    }
    
    private void ReturnStartPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime); 
    }
    private void Flip()
    {
        if(transform.position.x>player.transform.position.x)
        transform.rotation = Quaternion.Euler(0,0,0);
        else
        transform.rotation = Quaternion.Euler(0,180,0);
    }
    IEnumerator PlayavispaIdleSound()
    {
        AvispaIdle.AvispaIdleSound();
        yield return new WaitForSeconds(idleSoundDelay);
        canPlayAvispaIdle = true; 
    }
    
    IEnumerator PlayattackingSound()
    {
        AvispaAttackSound.AttackAvispaSound();
        yield return new WaitForSeconds(attackavispaDelay);
        canPlayAvispaAttackSound = true; 
    }

<<<<<<< Updated upstream
=======
    
    bool RightRay => Physics2D.Raycast(transform.position, Vector2.right, rayDistance, detectionLayer);
    bool LeftRay => Physics2D.Raycast(transform.position, Vector2.left, rayDistance, detectionLayer);
    bool Die => health == 0;
>>>>>>> Stashed changes
}
