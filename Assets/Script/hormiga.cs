using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hormiga : MonoBehaviour
{
    public float speed = 5.0f;
    public CapsuleCollider2D cc;
    public Rigidbody2D rb;
    public GameManager GameManager;
    public Animator animatorController;
    SpriteRenderer spriteRenderer;

    public float pushForce = 100.0f;


    const string attack = "HORMIGA_ATTACK_IZQ";

    [Range(-1, 1)]
    public int initialFacingDirection = -1;
    int currentFacingDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        currentFacingDirection = initialFacingDirection;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
    }

    
}
