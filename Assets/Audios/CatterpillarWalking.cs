using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatterpillarWalking : MonoBehaviour

{
    private AudioSource audioSource;
    private bool isWalking;
    [SerializeField]
    public AudioClip OrugaWalkSFX;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void WalkingSoundCatterpillar()
    {
        audioSource.PlayOneShot(OrugaWalkSFX);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
