using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] boolVariable isWavesCompleted;
    [SerializeField] BossFactory bossFactory;
    bool HasBossSpawned = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (isWavesCompleted.boolValue == true && HasBossSpawned == false)
        {
            HasBossSpawned = true;
            BossController thisenemy = (BossController) bossFactory.GetProduct(new Vector2(0f, 6f));

        }
    }
}
