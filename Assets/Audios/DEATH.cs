using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATH : MonoBehaviour
{
    private AudioSource audioSource;
    private bool IsDead;
    [SerializeField]
    AudioClip stepsSFX;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayDeathSound()
    {

        audioSource.PlayOneShot(stepsSFX);
        
    }
}
