using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatterpillarAttack : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isAttacking; 
    [SerializeField]
    public AudioClip OrugaAtaqueFoleyEditado; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    
    public void AttackingOruga()
    {
        audioSource.PlayOneShot(OrugaAtaqueFoleyEditado); 
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
