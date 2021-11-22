using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Pausa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Pantalla_Inicio");
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
