using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatterpillarWalking : MonoBehaviour

{
    private AudioSource audioSource;
    private bool isWalking;
    [SerializeField]
    public AudioClip OrugaWalkFoleyEdit;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void SoundWalkingCatterpillar()
    {
        audioSource.PlayOneShot(OrugaWalkFoleyEdit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
