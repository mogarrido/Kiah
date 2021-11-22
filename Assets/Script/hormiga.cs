using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class hormiga : MonoBehaviour
{
    
    [SerializeField]

    public float speed = 5.0f;
    public CapsuleCollider2D cc;
    public Rigidbody2D rb;
    public GameManager GameManager;
    public Animator animatorController;
    SpriteRenderer spriteRenderer;

[SerializeField]
   public HormigaSounds hormigaSound; 
    [SerializeField]
    

    public float pushForce = 100.0f;

<<<<<<< Updated upstream

    const string attack = "HORMIGA_ATTACK_IZQ";

    [Range(-1, 1)]
    public int initialFacingDirection = -1;
    int currentFacingDirection;
    bool canPlayHormigaSound = true; 
=======
    [SerializeField]
    public HormigaSounds hormigaSound; 
    float footstepsDelay = 2f;
    bool canPlayHormigaSound = true;

   [SerializeField]
   public AttackAntSound antAttacking;
   float attackSoundDelay = 2f;
   bool canplayantAttacking = true;
    [SerializeField]
   public StarSoundOne starSoundOne; 
     float starSoundDelay = 2f; 
     bool canPlayStarSoundOne; 


>>>>>>> Stashed changes
    

    // Start is called before the first frame update
    void Start()
    {
        currentFacingDirection = initialFacingDirection;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        Move();
        canPlayHormigaSound = true;   
        
=======
        if (Die)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("die");
                DeleteFromScene();
                canPlayHormigaSound = false;
                canPlayStarSoundOne = true; 
                StartCoroutine(PlaySoundStarOne());
            }
            return;
        }
        if(CanAttack && !isAttacking)
        {
            lastFlip = spr.flipX;
            StartCoroutine(AttackCoroutine("attack", attackClip, actualCoroutine));
            StopCoroutine(actualCoroutine);
            canplayantAttacking = false;
            StartCoroutine(PlayattackSound());
        }
        if(isAttacking && CanAttack)
        {
            spr.flipX = RightRay ? false : LeftRay ? true : spr.flipX;
        } 

>>>>>>> Stashed changes
    }
    
   


    void Move()
    {

        if(animatorController.GetCurrentAnimatorStateInfo(0).IsName("HORMIGA_WALK"))
         this.transform.Translate(speed * Time.deltaTime * currentFacingDirection,0,0);
          
    }
    
   
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Limit")
        {
            currentFacingDirection *= -1;
            float dir = transform.localScale.x * -1;
            transform.localScale = new Vector3(dir, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            //saber  si el player esta a la derecha o a la izquierda de la posicion 
            if(other.transform.position.x < transform.position.x)
            {
                //esta a la izquierda
                if(currentFacingDirection == 1 )
                {
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                    currentFacingDirection *= -1;
                }
                playerRb.AddForce(new Vector2(-pushForce, 0.0f));
            }else if(other.transform.position.x > transform.position.x)
            {
                 if(currentFacingDirection == -1)
                 {
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                     currentFacingDirection *= -1;
                    
                }
                 playerRb.AddForce(new Vector2(pushForce, 0.0f));
            }
            animatorController.Play(attack);
        }
<<<<<<< Updated upstream
    }

    
=======

        if(canPlayHormigaSound)
        {
            canPlayHormigaSound = true;
            StartCoroutine(PlayFootSteps());
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
    IEnumerator PlayFootSteps()
    {
        hormigaSound.hormigaSound();
        yield return new WaitForSeconds(footstepsDelay);
        canPlayHormigaSound = true;
    }
    IEnumerator PlayattackSound()
    {
        antAttacking.AttackSound();
        yield return new WaitForSeconds(attackSoundDelay);
        canplayantAttacking = true; 
    }

    IEnumerator PlaySoundStarOne()
    {
        starSoundOne.estrella1Sound();
        yield return new WaitForSeconds(starSoundDelay);
        canPlayStarSoundOne = true; 
    }
    

    bool RightRay => Physics2D.Raycast(transform.position, Vector2.right, rayDistance, detectionLayer);
    bool LeftRay => Physics2D.Raycast(transform.position, Vector2.left, rayDistance, detectionLayer);
    bool Die => health == 0;

>>>>>>> Stashed changes
}
