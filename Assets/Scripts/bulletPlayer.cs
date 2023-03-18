using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : PooledObject
{
    private Vector2 moveDirection;
    [SerializeField] float moveSpeed;

    

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyParent>(out EnemyParent enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
            Release();
        }
    }
}
