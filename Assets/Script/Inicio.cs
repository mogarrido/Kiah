using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene("IntroVideo");
    }

     public void SkipIntro()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void Creditos ()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void FinalVideoToCredits()
    {
        SceneManager.LoadScene("");
    }

    /*public void Vida()
    {
        if (true)
        {
            GameManager.instance.GetPlayer.Life();
            GameManager.instance.GetHealthBar.SetValue(GameManager.instance.GetPlayer.GetHealth);
        }
    }*/
}
