using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;

    [SerializeField] int BossCurrentHP;
    [SerializeField] int BossMaxHP;
    [SerializeField] BossMovement bossMovement;
    [SerializeField] GameObject[] BossArms;
    [SerializeField] BulletSpawnerPrime[] normalSpawners;
    int nSpawners;
    [SerializeField] BulletSpawnerPrime lastResort;
    [SerializeField] float bossThreshold;

    void Awake()
    {
        bossMovement = GetComponent<BossMovement>();
    }

    void Start()
    {
        BossCurrentHP = BossMaxHP;
        nSpawners = normalSpawners.Length;
        BossArms[0].SetActive(false);
        BossArms[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bossThreshold = (BossCurrentHP * 10) / BossMaxHP;
        if (bossThreshold <= 8f && !BossArms[0].activeSelf)
        {
            BossArms[0].SetActive(true);
        }
        if (bossThreshold <= 4f && !BossArms[1].activeSelf)
        {
            BossArms[1].SetActive(true);
        }
        if(bossThreshold <= 1 && !bossMovement.isDying)
        {
            for(int i = 0; i < nSpawners; i++)
            {
                normalSpawners[i].willFire = false;
            }
            bossMovement.isDying = true;
        }
        if(bossMovement.finalMove)
        {
            lastResort.willFire = true;
        }
    }


    public void TakeDamage(int damage)
    {
        BossCurrentHP -= damage;
    }
}
