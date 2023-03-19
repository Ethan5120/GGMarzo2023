using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : bulletPrime
{
    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyParent>(out EnemyParent enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
            Release();
        }

        if (collision.gameObject.TryGetComponent<Wall>(out Wall wallComponent))
        {
            Release();
        }
    }
}
