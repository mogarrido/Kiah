using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbsound: MonoBehaviour
{
     private AudioSource audioSource;
    private bool isClimbing;
    [SerializeField]
    public Audioclip jumpToClimb; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void ClimbingSound()
    {

        audioSource.PlayOneShot(jumpToClimb);
        
        
    }
}
