using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemyFather : PooledObject
{
    protected Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    protected float damage = 1;
    public enum PolarityType { CYANB, PURPLEB, ORANGEB }
    public PolarityType bType;

    protected void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            playerComponent.CheckPolarity(bType, damage);
            Release();
        }

        if (collision.gameObject.TryGetComponent<Wall>(out Wall wallComponent))
        {
            Release();
        }
    }
}
