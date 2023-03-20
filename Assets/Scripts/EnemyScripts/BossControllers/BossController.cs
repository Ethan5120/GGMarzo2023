using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : PooledObject, IProduct
{
    [SerializeField] float MaxHP;
    [SerializeField] float HP;
    public enum enemyState { STARTING, ACTIVE };
    enemyState eState = enemyState.STARTING;
    protected bool HasFired = false;
    public float moveSpeed = 1;
    public firePattern[] streams;

    Rigidbody2D rb;
    Vector2 move, startLocation;


    public void Iniciar()
    {
        eState = enemyState.STARTING;
        startLocation = transform.position;
        rb = GetComponent<Rigidbody2D>();
        streams = GetComponentsInChildren<firePattern>();
        move.x = 0;
        move.y = 1;
        HP = MaxHP;
        HasFired = false;
    }

    public void Update()
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

    protected void SettingUp()
    {
        if (transform.position.y > startLocation.y - 2)
        {
            rb.velocity = new Vector2(move.x, -move.y) * moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            eState = enemyState.ACTIVE;
        }
    }


    protected void AttackMode()
    {
        if (HasFired == false)
        {
            for(int i = 0; i < streams.Length; i++)
            {
                streams[i].Fire();
            }
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
