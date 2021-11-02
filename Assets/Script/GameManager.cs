using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverObjetos;
    public GameObject Tutorial;
    public float coutTimer = 5;
    public TextMeshProUGUI playerMessage;
    // Start is called before the first frame update
    void Start()
    {
        Tutorial.SetActive(true);
        GameOverObjetos.SetActive(false);
        Time.timeScale = 1;
        playerMessage.text = $"Utiliza A y D para mover el personaje de izquierda a derecha";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Pausa_Pantalla");
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerMessage.text = $"Utiliza Spacebar para poder saltar, solo aplica cuando no estas en el tronco";
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerMessage.text = $"Utiliza H para lanzar una patada";
        }

        if (Input.GetKey(KeyCode.H))
        {
            playerMessage.text = $"Utiliza J para lanzar una piedra, K para lanzar una rama y L para disparar una flecha";
        }

        if (Input.GetKey(KeyCode.L))
        {
            playerMessage.text = $"Para escalar por el tronco utiliza W y para bajar utiliza S";
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerMessage.text = $"Para terminar con el tutorial por favor oprima P y Hasta aquí llega el final del tutorial y Recuerda que si quieres volver al menú principal solo debes oprimir Esc ;)";
        }

        if (Input.GetKey(KeyCode.P))
        {
            Tutorial.SetActive(false);
        }
    }

    public void GameOver()
    {
        GameOverObjetos.SetActive(true);
        Debug.Log("GAME OVER");
        Time.timeScale = 0;
    }

    public void Mensaje()
    {

    }

}
