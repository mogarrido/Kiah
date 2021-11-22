using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAntSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isAttacking;
    [SerializeField]
    public AudioClip AntAttack; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void AttackSound()
{
    audioSource.PlayOneShot(AntAttack);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
