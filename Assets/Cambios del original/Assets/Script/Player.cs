using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField,Range(0.1f, 15f)]
    float moveSpeed = 2;
    SpriteRenderer spr;
    Rigidbody2D rb2D;
    Animator anim;
    bool isAttacking = false;
    [SerializeField]
    AnimationClip attackClip;
    // Start is called before the first frame update

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        spr.flipX = FlipSprite;
    }

    IEnumerator Ataque()
    {
        isAttacking = true;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(attackClip.length);
        isAttacking = false;
    }

    Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    bool FlipSprite => Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
    bool Attack => Input.GetKey(KeyCode.H);

}
