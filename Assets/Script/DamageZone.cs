using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{

    public int damage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Einho e = other.GetComponent<Einho>();
            e.TakeDamage(damage);
        }
    }
}
