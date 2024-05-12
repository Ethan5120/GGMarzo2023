using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : PooledObject
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;


    [SerializeField] float MaxHP;
    [SerializeField] float HP;
    [SerializeField] EnemyMovement enemyMove;
    [SerializeField] BulletSpawnerPrime bulletSpawn;
    AudioSource deadSound;

    //DeleteThisLater
    void Awake()
    {
        enemyMove = GetComponent<EnemyMovement>();
        bulletSpawn = GetComponent<BulletSpawnerPrime>();
        HP = MaxHP;
        bulletSpawn.willFire = false;
        enemyMove.currentTarget = Random.Range(0, enemyMove.maxRange);
        enemyMove.reachedFirst = false;
    }
    public void Iniciar()
    {
        enemyMove = GetComponent<EnemyMovement>();
        bulletSpawn = GetComponent<BulletSpawnerPrime>();
        HP = MaxHP;
        bulletSpawn.willFire = false;
        enemyMove.currentTarget = Random.Range(0, enemyMove.maxRange);
        enemyMove.reachedFirst = false;
    }


    void Update()
    {
        if(!bulletSpawn.willFire && enemyMove.reachedFirst)
        {
            bulletSpawn.willFire = true;
        }
    }



    public void TakeDamage(float damageAmount)
    {
        if(enemyMove.reachedFirst)
        {
            HP -= damageAmount;

            if (HP <= 0)
            {
                Die();
            }
        }
    }

    protected void Die()
    {
        GM.currentScore += 50;
        deadSound?.Play();
        Release();
    }
}
