using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : Collectable
{
    Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void Collect() => animator.SetTrigger("destroy");
    void RemoveFromScene() => Destroy(gameObject);
}
