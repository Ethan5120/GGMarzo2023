using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyWaveList", menuName = "Assets/EnemyList", order = 1)]
public class EnemyWaveList : ScriptableObject
{
    public List<GameObject> enemyList = new List<GameObject>();
}
