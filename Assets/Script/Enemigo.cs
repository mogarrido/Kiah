using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Enemigo : MonoBehaviour
{
    [SerializeField,Range(0.1f, 15f)]
    float moveSpeed = 2;

    SpriteRenderer spr;
    Animator anim;
    Rigidbody2D rb2D;
    Collider2D col2D; 
    int initialFacingDirection = -1;
    int currentFacingDirection;

    void Start()
    {
        currentFacingDirection = initialFacingDirection;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime * currentFacingDirection,0,0);
    }

    void OnCollision(Collision2D other)
    {
        if (other.gameObject.tag == "Limit")
        {
            currentFacingDirection *= -1;
            spr.flipX = FlipSprite;
        }
    }
    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();
    }

    Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    bool FlipSprite => col2D ? true : spr.flipX;
}
