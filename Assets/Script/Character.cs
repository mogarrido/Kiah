using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Character : MonoBehaviour
{
    [SerializeField,Range(0.1f, 15f)]
    float moveSpeed = 2;
    [SerializeField,Range(0.1f, 15f)]
    float jumpForce = 7;
    SpriteRenderer spr;
    Animator anim;
    Rigidbody2D rb2D;

    //Raycast Things
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField]
    LayerMask detectionLayer;

    bool isAttacking = false;
    [SerializeField]
    AnimationClip attackClip;


    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        spr.flipX = FlipSprite;
        if(IsJumping && Grounding)
        {
            Jump();
        }
        if(Attack && !isAttacking)
        {
            StartCoroutine(DoAttack());
        }
    }

    void Jump()
    {
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetTrigger("Jump");
    }

    IEnumerator DoAttack()
    {
        isAttacking = true;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(attackClip.length);
        isAttacking = false;
    }

    void LateUpdate()
    {
        anim.SetFloat("Axis", Mathf.Abs(Axis.x));
        anim.SetBool("Ground", Grounding);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    bool FlipSprite => Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
    bool IsJumping => Input.GetButtonDown("Salto");
    bool Grounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, detectionLayer);
    bool Attack => Input.GetButtonDown("Attack");

}
