using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Einho player;
    [SerializeField]
    HealthBarEinho healthBar;
    [SerializeField]
    HealthBarNaelie healthBarNaelie;

    public static GameManager instance;

    void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    void OnEnable() => Inittialize();

    void OnLevelWasLoaded(int level)
    {
        Inittialize();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Pausa_Pantalla");
        }

    }

    void Inittialize()
    {
        if(SceneManager.GetActiveScene().name != "Pausa_pantalla" 
        && SceneManager.GetActiveScene().name != "Pantalla_Inicio"
        && SceneManager.GetActiveScene().name != "GameOver"
        && SceneManager.GetActiveScene().name != "IntroVideo"
        && SceneManager.GetActiveScene().name != "Creditos"
        && SceneManager.GetActiveScene().name != "EndingVideo")
        {
            player = GameObject.FindWithTag("Player").GetComponent<Einho>();
            healthBar = FindObjectOfType<HealthBarEinho>();
        }
        if(SceneManager.GetActiveScene().name == "Naelie_Level")
        {
            healthBarNaelie = FindObjectOfType<HealthBarNaelie>();   
                 }
    }

    bool InGameplay(int level) => level > 2 && level < 5;
    public HealthBarEinho GetHealthBar => healthBar;
    public Einho GetPlayer => player;
    public HealthBarNaelie GetHealthBarNaelie => healthBarNaelie;
    // public Enemy GetEnemy => enemy;

}
