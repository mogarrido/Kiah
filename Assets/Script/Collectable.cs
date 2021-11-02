using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType{
    NONE,
    STAR,
    ROCK,
    STICK
}
public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Einho character = other.GetComponent<Einho>();
            if(character != null){
                character.AddItem(type);
            }
        }
    }
}
