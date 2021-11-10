using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepEinho : MonoBehaviour
{
    private AudioSource audioSource; 
    private bool IsMoving; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis ("Vertical") < 0 ) IsMoving = true; 
        else IsMoving = false; 

        if (IsMoving && !audioSource.isPlaying) audioSource.Play (); 
        if (!IsMoving)audioSource.Stop(); 
    }
}
