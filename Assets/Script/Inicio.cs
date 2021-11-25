using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{

    [SerializeField]
    Button btnStart;
    [SerializeField]
    Button btnCredits;
    [SerializeField]
    Button btnFinalVideo;
    [SerializeField]
    Button btnSkip;
    AudioSource aud;
    [SerializeField]
    AudioClip clickSfx;
    [SerializeField]
    float responseTime = 1f;

    void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    void Start()
    {
        if(btnStart != null)
        {
            btnStart.onClick.AddListener(StartGame);
        }
        if(btnCredits != null)
        {
            btnCredits.onClick.AddListener(Creditos);
        }
        if(btnFinalVideo != null)
        {
            btnFinalVideo.onClick.AddListener(FinalVideoScene);
        }
        if(btnSkip != null)
        {
            btnSkip.onClick.AddListener(SkipIntro);
        }

    }

    public void StartGame()
    {
        aud.PlayOneShot(clickSfx);
        StartCoroutine(buttonResponse("IntroVideo"));
    }

    public void SkipIntro()
    {
        aud.PlayOneShot(clickSfx);
        StartCoroutine(buttonResponse("SampleScene"));
    }

    public void Creditos ()
    {
        aud.PlayOneShot(clickSfx);
        StartCoroutine(buttonResponse("Creditos"));
    }

    public void FinalVideoScene()
    {
        aud.PlayOneShot(clickSfx);
        StartCoroutine(buttonResponse("EndingVideo"));
    }

    IEnumerator buttonResponse(string sceneName)
    {
        yield return new WaitForSeconds(responseTime);
        SceneManager.LoadScene(sceneName);
    }

    /*public void Vida()
    {
        if (true)
        {
            //GameManager.instance.GetPlayer.Life();
            GameManager.instance.GetHealthBar.SetValue(GameManager.instance.GetPlayer.GetHealth);
        }
    }*/
}
