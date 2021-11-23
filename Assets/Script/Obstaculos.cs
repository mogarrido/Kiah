using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public float speed = 2.0f;
    protected int obstacleDamage = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0,speed * Time.deltaTime * -1,0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MakeDamageToPlayer();
    }

    void MakeDamageToPlayer()
    {
        GameManager.instance.GetPlayer.Obstacle(obstacleDamage);
        GameManager.instance.GetHealthBar.SetValue(GameManager.instance.GetPlayer.GetHealth);
    }
}
