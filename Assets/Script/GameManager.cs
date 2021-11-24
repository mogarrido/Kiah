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
    HealthBar healthBar;

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

    void OnLevelWasLoaded(int level) => Inittialize();

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Pausa_Pantalla");
        }

    }

    void Inittialize()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Einho>();
        healthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
    }

    public HealthBar GetHealthBar => healthBar;
    public Einho GetPlayer => player;
    // public Enemy GetEnemy => enemy;

}
