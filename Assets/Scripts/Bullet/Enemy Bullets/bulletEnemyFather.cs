using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemyFather : bulletPrime
{
    public enum PolarityType { REDB, BLUEB, YELLOWB }
    public PolarityType bType;

    override protected void OnTriggerEnter2D(Collider2D collision)
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
