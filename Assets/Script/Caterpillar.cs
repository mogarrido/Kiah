using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : Enemy
{
    [SerializeField]
    float sleepTime = 2f;
    [SerializeField]
    float patrolTime = 5f;
    float patrolTimer = 0f;

    void Start()
    {
        StartCoroutine(IdleCoroutine(sleepTime, "patrol"));
    }

    public override IEnumerator IdleCoroutine(float duration, string stateName)
    {
        anim.SetBool(stateName, false);
        yield return new WaitForSeconds(duration);
        StartCoroutine(MovementCoroutine(patrolTime, "patrol"));
    }

    public override IEnumerator MovementCoroutine(float duration, string stateName)
    {
        anim.SetBool(stateName, true);
        spr.flipX = !spr.flipX;
        direction = new Vector2(-direction.x, direction.y);
        while(true)
        {
            patrolTimer += Time.deltaTime;
            if(patrolTimer >= patrolTime)
            {
                patrolTimer = 0f;
                StartCoroutine(IdleCoroutine(sleepTime, "patrol"));
                break;
            }
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
