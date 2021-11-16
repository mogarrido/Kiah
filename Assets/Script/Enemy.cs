using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected AnimationClip attackClip;
    protected Animator anim;
    protected SpriteRenderer spr;
    [SerializeField, Range(0, 200)]
    protected int health = 100;
    [SerializeField, Range(0, 20)]
    protected int damage = 10;
    [SerializeField]
    protected Vector2 direction = Vector2.right;
    [SerializeField, Range(0.1f, 15f)]
    protected float moveSpeed = 3f;
    protected bool isAttacking = false;
    protected bool isMakingDamage = false;
    [SerializeField]
    float attackTime;
    protected bool lastFlip = false;

    protected bool diying = false;
    protected bool isRecivingDamage = false;

    [SerializeField]
    Object srcStar;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    public bool IsRecivingDamage { get => isRecivingDamage; set => isRecivingDamage = value;}

    public int GetHealth => health;

    public void RecivingDamage(int damage) => health -=  health - damage > 0 ? damage : health;

    public int GetDamage => damage;

    public void DeleteFromScene()
    {
        Instantiate(srcStar, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public virtual IEnumerator IdleCoroutine(float duration, string stateName)
    {
        yield return new WaitForSeconds(duration);
    }

    public virtual IEnumerator MovementCoroutine(float duration, string stateName)
    {
        yield return new WaitForSeconds(duration);
    }

    public virtual IEnumerator AttackCoroutine(string stateName, AnimationClip clip, IEnumerator coroutine)
    {
        isAttacking = true;
        anim.SetTrigger(stateName);
        yield return new WaitForSeconds(clip.length + attackTime);
        isAttacking = false;
        isMakingDamage = false;
        spr.flipX = lastFlip;
        StartCoroutine(coroutine);
    }

    public IEnumerator CanelAttackDelay()
    {
        yield return new WaitForSeconds(attackClip.length);
        isRecivingDamage = false;
    }
}
