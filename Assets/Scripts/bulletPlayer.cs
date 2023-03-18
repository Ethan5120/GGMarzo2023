using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : PooledObject
{
    private Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    private float damage = 1;
    

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyParent>(out EnemyParent enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
            Release();
        }
    }
}
