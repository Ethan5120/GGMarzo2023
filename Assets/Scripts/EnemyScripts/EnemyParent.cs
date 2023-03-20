using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyParent : PooledObject, IProduct
{
    [SerializeField] float MaxHP;
    [SerializeField] float HP;
    [SerializeField] floatVariable Score;
    public enum enemyState { STARTING, ACTIVE };
    enemyState eState = enemyState.STARTING;
    public firePattern stream;
    protected bool HasFired = false;
    protected int distanceToMove;
    public float moveSpeed = 1;
    Rigidbody2D rb;
    AudioSource deadSound;
    Vector2 move, startLocation;

    protected void Start()
    {

    }

    public void Iniciar()
    {
        deadSound = this.gameObject.GetComponent<AudioSource>();
        eState = enemyState.STARTING;
        startLocation = transform.position;
        distanceToMove = Random.Range(2, 7);
        rb = GetComponent<Rigidbody2D>();
        stream = this.gameObject.GetComponent<firePattern>();
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
        if (transform.position.y > startLocation.y - distanceToMove)
        {
            rb.velocity = new Vector2(move.x, - move.y) * moveSpeed;
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
        Score.floatValue += 50;
        deadSound.Play();
        //GetComponent<lootBag>().InstantiateLoot(transform.position);
        Release();
    }
}
