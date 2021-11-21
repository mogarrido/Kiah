using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATH : MonoBehaviour
{
   private AudioSource audioSource;
    private bool IsDying; 
    [SerializeField]
    Audioclip DeathsFX;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameobject.GetComponent<AudioSource>();
    }

    public void PlayDeathSound()
    {

        audioSource.PlayOneShot(DeathsFX);
    }
}
