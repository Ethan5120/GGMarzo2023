using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPrime : PooledObject
{
    protected Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    protected float damage = 1;


    protected void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<Wall>(out Wall wallComponent))
        {
            Release();
        }
    }
}
