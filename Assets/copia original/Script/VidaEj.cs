using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VidaEj : MonoBehaviour
{
    public int randomNumber;
    public TMP_InputField playerInput; 
    public TextMeshProUGUI  playerMessage; 
    public int temporal;
    public int minRandom = 0;
    public int maxRandom = 0; 
    public int lives =3; 
    int initiallives; 
    public int tryouts; 
    public int gameOvermessage; 
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range (minRandom,maxRandom);
        playerMessage.text = $"Lives; {lives}";
        Debug.Log ($"El numero random es: {randomNumber}");
        initiallives = lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerGuess()
    {
        if(lives ==0)
        {
            return;
        }
        Debug.Log (playerInput.text);
        int temporal;
        int.TryParse(playerInput.text, out temporal);

       if (randomNumber == temporal)
       {
       Debug.Log("Acertaste");
       }
       
       else
       {
           Debug.Log("Fallaste");
           lives = lives - 1; 
           playerMessage.text = $"Total Lives ={lives} ";
        }
        
       if (lives == 0)
       {
           Debug.Log( "GameOver"); 
           playerMessage.text = $"lives: 0";
        } 
    }
    public void Restart()
    { 
        if (lives == 0)
        {
            lives = initiallives; 
            playerMessage.text = $"Total Lives ={initiallives} ";
        }

    }
}
