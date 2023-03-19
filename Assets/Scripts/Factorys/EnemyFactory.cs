using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Factory
{
    public EnemyParent enemyPrefab;
    public EnemyPool ePool;

    public override IProduct GetProduct(Vector3 position)
    {
        ePool = GameObject.FindObjectOfType<EnemyPool>();
        EnemyParent enemyPrefab = (EnemyParent)ePool.Get();

        enemyPrefab.transform.position = position;
        enemyPrefab.Iniciar();
        return enemyPrefab;
    }
}

