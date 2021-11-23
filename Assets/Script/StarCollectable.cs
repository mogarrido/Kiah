using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : Collectable
{
    [SerializeField]
    public StarSoundOne starSoundOne; 
     float starSoundDelay = 2f; 
     bool canPlayStarSoundOne; 

    Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
        if (canPlayStarSoundOne)
        {
            canPlayStarSoundOne = true; 
            StartCoroutine(PlaySoundStarOne());
        }
    }
    
    public void Collect() => animator.SetTrigger("destroy");
    void Collected() 
    {
        canPlayStarSoundOne = true; 
        StartCoroutine(PlaySoundStarOne());
    }
    
    void RemoveFromScene() => Destroy(gameObject);

     IEnumerator PlaySoundStarOne()
    {
        starSoundOne.estrella1Sound();
        yield return new WaitForSeconds(starSoundDelay);
        canPlayStarSoundOne = true; 
    }
}
