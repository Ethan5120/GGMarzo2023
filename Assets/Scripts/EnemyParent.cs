using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyParent : PooledObject
{
    [SerializeField] float HP;
    public enum enemyState { STARTING, ACTIVE };
    enemyState eState = enemyState.STARTING;
    public firePattern stream;
    protected bool HasFired = false;
    protected int distanceToMove;
    public float moveSpeed = 1;
    Rigidbody2D rb;
    Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceToMove = Random.Range(1, 3);
        stream = this.gameObject.GetComponent<firePattern>();
        eState = enemyState.STARTING;
        move.x = 0;
        move.y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (eState)
        {
            case enemyState.STARTING:
                {
                    SettingUp();
                    break;
                }

            case enemyState.ACTIVE:
                {
                    AttackMode();
                    break;
                }
        }
    }

    void SettingUp()
    {
        if (transform.position.y < transform.position.y - distanceToMove)
        {
            rb.velocity = new Vector2(move.x, - move.y) * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            eState = enemyState.ACTIVE;
        }
    }


    void AttackMode()
    {
        if (HasFired == false) 
        {
            stream.Fire();
            HasFired = true;
        }
    }


    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        //GetComponent<lootBag>().InstantiateLoot(transform.position);
        Release();
    }

}
