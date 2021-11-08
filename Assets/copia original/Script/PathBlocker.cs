using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBlocker : MonoBehaviour
{
    public CollectableType typeRequired = CollectableType.NONE;
    public int requiredAmount = 1;
    Einho character;
    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<Einho>();
        character.OnItemCollected += ItemCollected;
    }

    void OnDisable(){
        character.OnItemCollected += ItemCollected;
    }


    void ItemCollected(CollectableType type){
        if(type != typeRequired) return;
        if(character.GetItemCount(type) >= requiredAmount){
            //cambiar codigo por una animacion o algo 
            Destroy(this.gameObject);
        }
    }
}
