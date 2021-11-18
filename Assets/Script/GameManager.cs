using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Tutorial;
    public float coutTimer = 5;
    
    [SerializeField]
    Einho player;
    [SerializeField]
    HealthBar healthBar;
    //[SerializeField]
    // Enemy enemy;

    
    public Sprite Tutorial_2;
    public Sprite Tutorial_3;
    public Sprite Tutorial_4;

    public Sprite Tutorial_5;
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
        Tutorial.SetActive(true);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Pausa_Pantalla");
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<Image>().sprite = Tutorial_2;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.gameObject.GetComponent<Image>().sprite = Tutorial_3;
        }

        if (Input.GetKey(KeyCode.L))
        {
            this.gameObject.GetComponent<Image>().sprite = Tutorial_4;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.GetComponent<Image>().sprite = Tutorial_5;
        }

        if (Input.GetKey(KeyCode.P))
        {
            Tutorial.SetActive(false);
        }
    }

    public HealthBar GetHealthBar => healthBar;
    public Einho GetPlayer => player;
    // public Enemy GetEnemy => enemy;

}
