using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : PooledObject
{
    [SerializeField] float HP;
    protected enum enemyState { STARTING, ACTIVE };
    enemyState eState = enemyState.STARTING;
    public firePattern streams;
    protected bool HasFired = false;


    void Start()
    {
        streams = this.gameObject.GetComponent<firePattern>();
        eState = enemyState.STARTING;
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
        eState = enemyState.ACTIVE;
    }


    void AttackMode()
    {
        if (HasFired == false) 
        {
            streams.Fire();
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
