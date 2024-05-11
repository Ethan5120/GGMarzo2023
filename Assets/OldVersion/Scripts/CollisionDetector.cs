using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : PooledObject
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            //playerComponent.Heal();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.TryGetComponent<Wall>(out Wall wallComponent))
        {
            Destroy(this.gameObject);
        }
    }
}
