using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : Collectable
{
    Animator animator;
    public string AnimationName  = "POLVO";
    public float DestroyAfter = 1.0f;

    void Start(){
        animator = GetComponent<Animator>();
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.tag == "Player")
        {
            
            animator.Play(AnimationName);
            Destroy(this.gameObject, DestroyAfter);
        }
    }
}
