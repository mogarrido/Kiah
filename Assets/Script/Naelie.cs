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
    Collider2D clawsheadcolliderLeft;
    [SerializeField]
    Collider2D clawsheadcolliderRight;
    [SerializeField]
    Collider2D throwheadcolliderLeft;
    [SerializeField]
    Collider2D throwheadcolliderRight;

    //Raycast things
    [SerializeField, Range(0.1f, 20f)]
    float rayDistance = 5f;
    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField]
    LayerMask detectionLayer;

    bool canAttack = true;
    [SerializeField]
    float delayAttack;
    [SerializeField, Range(0.1f, 15f)]
    float maxRangedDistance = 3f;
    [SerializeField]
    float lastPhase = 0f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = areaColor;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.right * rayDistance);
        Gizmos.DrawRay(transform.position, Vector2.left * rayDistance);
    }
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
                anim.SetBool("patrol", true);
                spr.flipX = !spr.flipX;
                StartCoroutine(actualCoroutine);
                break;
            }
            yield return null;
        }
    }

    public override IEnumerator MovementCoroutine(float duration, string stateName)
    {
        direction = new Vector2(-direction.x, direction.y);
        while(true)
        {
            if((RightRay || LeftRay) && canAttack)
            {
                actualCoroutine = MovementCoroutine(patrolTime, "patrol");
                Attack();
                break;
            }
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
        StartCoroutine(actualCoroutine);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        anim.SetFloat("Phase", Phase);
        anim.SetFloat("Health", health);
        if(lastPhase < Phase)
        {
            lastPhase = Phase;
            StopAllCoroutines();
            patrolTimer = 0f;
            sleepTimer = 0f;
            anim.SetTrigger("Death");
            spr.flipX = false;
            direction = Vector2.right;
            canAttack = true;
            anim.SetBool("patrol", false);
            anim.SetBool("Ranged", false);
        }
    }

    void Attack()
    {
        canAttack = false;
        anim.SetBool("patrol", false);
        anim.SetTrigger("Attack");
        anim.SetBool("Ranged", PlayerIsRanged);
    }

    void ResetAttack()
    {
        StartCoroutine(ResetAttackRoutine());
    }

    IEnumerator ResetAttackRoutine()
    {
        yield return new WaitForSeconds(delayAttack);
        canAttack = true;
        StartCoroutine(actualCoroutine);
    }

    new protected void Update()
    {
        base.Update();
    }

    void ResetStates()
    {
        actualCoroutine = IdleCoroutine(sleepTime, "patrol");
        StartCoroutine(actualCoroutine);
    }
    void MakeDamageToPlayer()
    {
        GameManager.instance.GetPlayer.RecivingDamage(damage);
        GameManager.instance.GetHealthBar.SetValue(GameManager.instance.GetPlayer.GetHealth);
    }

    void ActivateCollider()
    {
        if(spr.flipX)
        {
            clawsheadcolliderLeft.enabled = true;
            clawsheadcolliderRight.enabled = false;
        }
        else
        {
            clawsheadcolliderLeft.enabled = false;
            clawsheadcolliderRight.enabled = true;
        }
    }

    void ActivoColliderThrow()
    {
        if (spr.flipX)
        {
            throwheadcolliderLeft.enabled = true;
            throwheadcolliderRight.enabled = false;
        }
        else
        {
            throwheadcolliderLeft.enabled = false;
            throwheadcolliderRight.enabled = true;
        }
    }

    void DesableCollider()
    {
        clawsheadcolliderLeft.enabled = false;
        clawsheadcolliderRight.enabled = false;
    }

    void DesactivoColliderThrow()
    {
        throwheadcolliderLeft.enabled = false;
        throwheadcolliderRight.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!isMakingDamage)
        {
            isMakingDamage = true;
            MakeDamageToPlayer();
        }
    }

    float Phase => health >= 100 ?  0 : health < 100f && health > 50f ? 1 : health > 0 ? 2 : 3;
    //float Phase => health >= 100 ?  0 : 1;
    bool RightRay => Physics2D.Raycast(transform.position, Vector2.right, rayDistance, detectionLayer) && !spr.flipX;
    bool LeftRay => Physics2D.Raycast(transform.position, Vector2.left, rayDistance, detectionLayer) && spr.flipX;
    bool PlayerIsRanged => Vector2.Distance(transform.position, GameManager.instance.GetPlayer.transform.position) >= maxRangedDistance;
}
