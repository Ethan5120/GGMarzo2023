using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : PooledObject
{
    [SerializeField] float HP;
    protected enum enemyState { STARTING, ACTIVE };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
