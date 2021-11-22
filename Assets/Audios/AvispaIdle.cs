using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvispaIdle : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMoving;
    [SerializeField]  
    public AudioClip Avispaidle; 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void AvispaIdleSound()
    {
        audioSource.PlayOneShot(Avispaidle);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
