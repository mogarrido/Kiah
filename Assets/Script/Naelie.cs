using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naelie : Boss
{
    [SerializeField]
    float sleepTime = 2f;
    [SerializeField]
    float patrolTime = 5f;
    float patrolTimer = 0f;
    float sleepTimer = 0f;
    //Attack area
    [SerializeField, Range(0.1f, 20f)]
    float areaRadius = 5f;
    [SerializeField]
    Color areaColor = Color.red;
    [SerializeField]
    LayerMask areaDetectionLayer;
    IEnumerator actualCoroutine;

    [SerializeField]
    Collider2D headcolliderLeft;
    [SerializeField]
    Collider2D headcolliderRight;

    //Raycast things
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField]
    LayerMask detectionLayer;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = areaColor;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.right * rayDistance);
        Gizmos.DrawRay(transform.position, Vector2.left * rayDistance);
    }

    // Hacer que cuando choque (player a boss) empieze el movimiento
    //Hacer ataques multiples
    //hacer transformaciones multiples y muertes multiples
    //Programar healthbar
    public override IEnumerator IdleCoroutine(float duration, string stateName)
    {
        anim.SetBool(stateName, false);
        while(true)
        {
            sleepTimer += Time.deltaTime;
            if(sleepTimer >= duration)
            {
                sleepTimer = 0f;
                actualCoroutine = MovementCoroutine(patrolTime, "patrol");
                StartCoroutine(actualCoroutine);
                break;
            }
            yield return null;
        }
    }

    public override IEnumerator MovementCoroutine(float duration, string stateName)
    {
        anim.SetBool(stateName, true);
        spr.flipX = !spr.flipX;
        direction = new Vector2(-direction.x, direction.y);
        while(true)
        {
            patrolTimer += Time.deltaTime;
            if(patrolTimer >= duration)
            {
                patrolTimer = 0f;
                actualCoroutine = IdleCoroutine(sleepTime, "patrol");
                StartCoroutine(actualCoroutine);
                break;
            }
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    /*avoid OnCollision2D(Collider2D collision)
    {
        StartCoroutine(MovementCoroutine(sleepTime, "patrol"));
    }*/

    // Start is called before the first frame update
    void Start()
    {
        actualCoroutine = IdleCoroutine(sleepTime, "patrol");
        StartCoroutine(IdleCoroutine(sleepTime, "patrol"));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        anim.SetFloat("Phase", Phase);
    }

    float Phase => health >= 100 ?  0 : health < 100f && health > 50f ? 1 : 2;
    bool RightRay => Physics2D.Raycast(transform.position, Vector2.right, rayDistance, detectionLayer);
    bool LeftRay => Physics2D.Raycast(transform.position, Vector2.left, rayDistance, detectionLayer);
    bool Die => health == 0;
}
