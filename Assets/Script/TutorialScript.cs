using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject Tutorial;

    public Sprite tutorialJump;

    public Sprite tutorialKick;

    public Sprite tutorialClimb;

    public Sprite tutorialEnd;

    // Start is called before the first frame update
    void Start()
    {
        Tutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<Image>().sprite = tutorialJump;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            this.gameObject.GetComponent<Image>().sprite = tutorialKick;
        }

        if(Input.GetKey(KeyCode.H))
        {
            this.gameObject.GetComponent<Image>().sprite = tutorialClimb;
        }

        if(Input.GetKey(KeyCode.S))
        {
            this.gameObject.GetComponent<Image>().sprite = tutorialEnd;
        }

        if(Input.GetKey(KeyCode.P))
        {
             Tutorial.SetActive(false);
        }
    }
}
