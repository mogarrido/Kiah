using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvispaAttackSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isAttacking;
    [SerializeField]
    public AudioClip avispaattack1; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void AttackAvispaSound()
    {
      audioSource.PlayOneShot(avispaattack1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
