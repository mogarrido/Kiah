using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbEinho : MonoBehaviour
{
     private AudioSource audioSource;
     private bool isClimbing; 
     [SerializeField]
     public AudioClip jumpToClimb; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void ClimbingSoundEinho()
    {
        audioSource.PlayOneShot(jumpToClimb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
