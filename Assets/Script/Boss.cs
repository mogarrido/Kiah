using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Boss : MonoBehaviour
{
    protected SpriteRenderer spr;
    protected Animator anim;
    [SerializeField]
    Object srcStar;
    protected bool isRecivingDamage = false;
    [SerializeField, Range(0, 200)]
    protected int health = 200;
    [SerializeField, Range(0, 20)]
    protected int damage = 20;
    protected float moveSpeed = 3f;
    [SerializeField]
    protected Vector2 direction = Vector2.right;
    protected bool dieying = false;
    protected bool isMakingDamage = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

     public bool IsRecivingDamage { get => isRecivingDamage; set => isRecivingDamage = value;}

    public int GetHealth => health;

    public void RecivingDamage(int damage) => health -=  health - damage > 0 ? damage : health;
    public int GetDamage => damage;
    public void PlayerMakeDamage()
    {
        anim.SetBool("Hurt", true);
    }

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void Update()
    {
        if(Die && !dieying)
        {
            dieying = true;
            anim.SetTrigger("Die");
            return;
        }
    }

    protected bool Die => health == 0;
}
