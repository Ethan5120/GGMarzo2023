using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : PooledObject, IProduct
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;


    [SerializeField] float MaxHP;
    [SerializeField] float HP;
    //Aqui referenciamos el script de mov
    [SerializeField] BulletSpawnerPrime bulletSpawn;
    AudioSource deadSound;


    public void Iniciar()
    {
        //Aqui randomizamos su objetivo a moverse
        bulletSpawn = GetComponent<BulletSpawnerPrime>();
        HP = MaxHP;
        bulletSpawn.willFire = false;
    }


    void Update()
    {
        if(!bulletSpawn.willFire)
        {
            bulletSpawn.willFire = true;
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
        GM.currentScore += 50;
        deadSound.Play();
        Release();
    }
}
