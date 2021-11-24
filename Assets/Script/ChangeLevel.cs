using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           SceneManager.LoadScene("Naelie_Level");
        }
        /*if(other.tag == "stuckcam")
        {
            Debug.Log("stuckcam");
            GameManager.instance.GetPlayer.GetVCam.Follow = null;
        }*/
    }

    /*void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "stuckcam")
        {
            GameManager.instance.GetPlayer.GetVCam.Follow = GameManager.instance.GetPlayer.transform;
        }
    }*/

}
