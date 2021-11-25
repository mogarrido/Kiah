using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrugaAttackSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isAttacking; 
    [SerializeField]
    public AudioClip OrugaAtaqueFoleyEditado; 
    public float sfxVolume;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    
    public void AttackingOruga()
    {
        audioSource.PlayOneShot(OrugaAtaqueFoleyEditado, sfxVolume); 
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
