using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSoundOne : MonoBehaviour
{
    private  AudioSource audioSource;
    private bool isDying;
    [SerializeField] 
    public AudioClip Estrella1; 
    [SerializeField, Range(0f, 15f)]
    float sfxVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void estrella1Sound()
    {
        audioSource.PlayOneShot(Estrella1, sfxVolume);
    }
}
