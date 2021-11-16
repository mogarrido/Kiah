using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Einho : MonoBehaviour
{
    [SerializeField, Range(0, 100)]
    int health = 100;
    [SerializeField, Range(0.1f, 15f)]
    float moveSpeed = 2;
    [SerializeField, Range(0.1f, 15f)]
    float jumpForce = 7;

    SpriteRenderer spr;
    Animator anim;
    Rigidbody2D rb2D;

    //Raycast things
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField]
    LayerMask detectionLayer;

    bool isAttacking = false;
    [SerializeField]
    AnimationClip attackClip;

    //Climb area
    [SerializeField, Range(0.1f, 20f)]
    float areaRadius = 5f;
    [SerializeField]
    Color areaColor = Color.red;
    [SerializeField]
    LayerMask areaDetectionLayer;

    [SerializeField, Range(0, 20)]
    protected int damage = 10;

    bool isClimbing = false;
    protected bool isMakingDamage = false;
    string AnimationName  = "EINHO_DEATH";


    [SerializeField, Range(0.1f, 20f)]
    float RayDistance = 5f;
    [SerializeField]
    Color RayColor = Color.red;
    [SerializeField]
    LayerMask DetectionLayer;

    [SerializeField]
    Collider2D headcolliderLeft;
    [SerializeField]
    Collider2D headcolliderRight;

    bool diying = false;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if(Die)
        {
            if(!diying)
            {
                diying = true;
                anim.SetTrigger("die");
            }
            return;
        }
        Movement();
        if(CanClimb && Axis.y > 0f)
        {
            isClimbing = true;
            spr.flipX = false;
        }
        else
        {
            if(!CanClimb)
            {
                isClimbing = false;
                if(rb2D.isKinematic)
                {
                    anim.SetBool("climb", false);
                    rb2D.isKinematic = false;
                }
            }
        }

        if(isClimbing)
        {
            rb2D.velocity = Vector2.zero;
            anim.SetBool("climb", true);
            anim.SetFloat("magnitude", Axis.magnitude);
            Climb();
        }
    }

    void Movement()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        if(!isClimbing)
        {
            spr.flipX = FlipSprite;
        }
        if(IsJumping && Grounding || IsJumping && CanClimb)
        {
            if(CanClimb)
            {
                isClimbing = false;
                anim.SetBool("climb", false);
                rb2D.isKinematic = false;
            }
            else
            {
                Jump();
            }
        }
        if(Attack && !isAttacking)
        {
            StartCoroutine(DoAttack());
        }
    }

    void Jump()
    {
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetTrigger("jump");
    }

    IEnumerator DoAttack()
    {
        isAttacking = true;
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(attackClip.length);
        isAttacking = false;
        isMakingDamage = false;
    }

    void MakeDamageToEnemy(Enemy enemy)
    {
        enemy.RecivingDamage(damage);
        enemy.IsRecivingDamage = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            if(!isMakingDamage)
            {
                isMakingDamage = true;
                Enemy enemy = collider.GetComponent<Enemy>();
                MakeDamageToEnemy(enemy);
            }
        }
    }

    void LateUpdate()
    {
        anim.SetFloat("AxisX", Mathf.Abs(Axis.x));
        anim.SetBool("ground", Grounding);
        anim.SetFloat("velY", rb2D.velocity.y);
    }

    void Climb()
    {
        transform.Translate(Axis.normalized * moveSpeed * Time.deltaTime);
        rb2D.isKinematic = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);

        Gizmos.color = areaColor;
        Gizmos.DrawWireSphere(transform.position, areaRadius);

        Gizmos.color = RayColor;
        Gizmos.DrawRay(transform.position, Vector2.right * RayDistance);
        Gizmos.DrawRay(transform.position, Vector2.left * RayDistance);

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

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    bool FlipSprite => Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
    bool IsJumping => Input.GetButtonDown("Jump");
    bool Grounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, detectionLayer);
    bool Attack => Input.GetButtonDown("Fire1");
    bool CanClimb => Physics2D.OverlapCircle(transform.position, areaRadius, areaDetectionLayer);
    public int GetHealth => health;
    public void RecivingDamage(int damage) => health -=  health - damage > 0 ? damage : health;
    bool RightRay => Physics2D.Raycast(transform.position, Vector2.right, RayDistance, DetectionLayer);
    bool LeftRay => Physics2D.Raycast(transform.position, Vector2.left, RayDistance, DetectionLayer);
    bool Die => health == 0;
}
