using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : Factory
{
    public BossController enemyPrefab;
    public EnemyPool ePool;

    public override IProduct GetProduct(Vector3 position)
    {
        BossController enemyPrefab = (BossController)ePool.Get();

        enemyPrefab.transform.position = position;
        enemyPrefab.Iniciar();
        return enemyPrefab;
    }
}
