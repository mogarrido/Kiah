using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEinho : MonoBehaviour
{
    
    private AudioSource audioSource; 
    private bool isAttacking; 
   [SerializeField]
    AudioClip AttackSFX; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    
    public void PlayAttackSound ()
    {
        audioSource.PlayOneShot (AttackSFX);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
