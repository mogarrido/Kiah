using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Einho : MonoBehaviour
{
    public float speed = 5.0f;
    public int maxHitPoints = 10;
    int currentHitPoints;
    bool canClimb = false;
    Rigidbody2D rb2d;
    public GameManager gameManager;
    public Animator animatorController;
    public float force = 20.0f;
    public Rigidbody2D characterRigidBody;
    public List<GameObject> estrellaPrefab;

    public int starsCollected {get; private set;}
    public int rocksCollected {get; private set;}
    public int stickCollected {get; private set;}

    public delegate void ItemCollected(CollectableType type);

    public ItemCollected OnItemCollected;

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoints;
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime,0,0);
            animatorController.Play("WALK_DER");
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(speed * Time.deltaTime * -1,0,0);
            animatorController.Play("WALK_IZQ");
        }

        if(Input.GetKey(KeyCode.H))
        {
            animatorController.Play("ATTACK_IZQUIERDA");
        }

        if(Input.GetKey(KeyCode.Space) && !canClimb)
        {
            //salto
            animatorController.Play("EINHO_JUMP_IZQ");
            characterRigidBody.AddForce(Vector2.up * force);
            characterRigidBody.velocity = Vector2.zero;

        }

        if(Input.GetKey(KeyCode.W) && canClimb)
        {
            this.transform.Translate(0,speed * Time.deltaTime * 1,0);
            animatorController.Play("CLIMB");
        }
        if(Input.GetKey(KeyCode.S) && canClimb)
        {
            this.transform.Translate(0,speed * Time.deltaTime * -1,0);
        }
    }


    public void TakeDamage(int damage)
    {
        currentHitPoints -= damage;
        Debug.Log($"Current Life; {currentHitPoints}");
        if(currentHitPoints == 0)
        {
            gameManager.GameOver();
            Debug.Log($"GAME OVER");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Ladder")
        {
            canClimb = true;
            rb2d.gravityScale = 0;
        }
            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ladder"){
            canClimb = false;
             rb2d.gravityScale = 1;
        }
            
    }

    public void AddItem(CollectableType type){
        switch(type){
            case CollectableType.STAR:
            starsCollected++;
            break;
            case CollectableType.ROCK:
            rocksCollected++;
            break;
            case CollectableType.STICK:
            stickCollected++;
            break;

        }
        OnItemCollected?.Invoke(type);
    }
    
    public int GetItemCount(CollectableType type){
        switch(type){
            case CollectableType.STAR:
            return starsCollected;
  
            case CollectableType.ROCK:
            return rocksCollected;
    
            case CollectableType.STICK:
            return stickCollected;
  

        }
        return 0;
    }
}
