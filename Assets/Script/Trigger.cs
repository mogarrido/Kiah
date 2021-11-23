using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform spawner;
    public List<GameObject> obstaclePrefab;
    public int randomPrefab = 0;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Inicio")
        {
            randomPrefab = Random.Range(0, obstaclePrefab.Count);
            Instantiate(obstaclePrefab[randomPrefab], spawner.position, Quaternion.identity);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Final")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
