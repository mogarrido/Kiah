using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrugaWalkSound : MonoBehaviour
{
     AudioSource audioSource;
    private bool IsWalking;
    [SerializeField]

    public AudioClip OrugaWalkFoley;
    public float sfxVolume; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void WalkingOruga()
    {
        audioSource.PlayOneShot(OrugaWalkFoley, sfxVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
