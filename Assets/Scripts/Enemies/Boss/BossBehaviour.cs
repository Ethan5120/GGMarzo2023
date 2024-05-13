using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] GameManagerSO GM;
    [Space(5)]
    [Header("Boss Data")]
    [SerializeField] int BossCurrentHP;
    [SerializeField] int BossMaxHP;
    [SerializeField] BossMovement bossMovement;
    [SerializeField] GameObject[] BossArms;
    [SerializeField] BulletSpawnerPrime[] normalSpawners;
    int nSpawners;
    [SerializeField] BulletSpawnerPrime lastResort;
    [SerializeField] float bossThreshold;
    [Space(5)]

    [Header("UI")]
    [SerializeField] Slider hpBar;

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
        if(bossMovement.reachedFirst && !bossMovement.isDying)
        {
            normalSpawners[0].willFire = true;
        }
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
        if(bossMovement.reachedFirst)
        {
            BossCurrentHP -= damage;
            hpBar.value = BossCurrentHP;
            if (BossCurrentHP < 0)
            {
                GM.cStageState = GameManagerSO.StageState.WinStage;
                gameObject.SetActive(false);
            }
        }
    }
}
