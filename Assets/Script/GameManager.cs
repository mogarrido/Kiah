using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   
    public float coutTimer = 5;
    
    [SerializeField]
    Einho player;
    [SerializeField]
    HealthBar healthBar;
    //[SerializeField]
    // Enemy enemy;

    
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

    // Start is called before the first frame update
    void Start()
    {
    
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Pausa_Pantalla");
        }

    }

    public HealthBar GetHealthBar => healthBar;
    public Einho GetPlayer => player;
    // public Enemy GetEnemy => enemy;

}
