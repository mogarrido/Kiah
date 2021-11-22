using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HormigaSounds : MonoBehaviour
{
<<<<<<< Updated upstream
    private  AudioSource audioSource;  
=======
    private  AudioSource audioSource;
    private bool isAttacking; 
    [SerializeField]  
    private bool IsMoving;
    [SerializeField]  
>>>>>>> Stashed changes
    public AudioClip hormigaSFX; 
   
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }
     
<<<<<<< Updated upstream
     public void hormigaSound()
     {
         audioSource.PlayOneShot(hormigaSFX); 
     }
=======
    public void hormigaSound()
    {
        audioSource.PlayOneShot(hormigaSFX); 

    }

   
>>>>>>> Stashed changes
    // Update is called once per frame
    void Update()
    {
        
    }
}
