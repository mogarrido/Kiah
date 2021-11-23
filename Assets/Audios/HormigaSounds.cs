using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HormigaSounds : MonoBehaviour
{
    private  AudioSource audioSource;
    private bool IsMoving;
    [SerializeField]  
    public AudioClip hormigaSFX; 
    [SerializeField, Range(0f, 15f)]
    float sfxVolume = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }
     
    public void hormigaSound()
    {
        audioSource.PlayOneShot(hormigaSFX, sfxVolume); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
