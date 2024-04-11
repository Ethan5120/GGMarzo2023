using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerV5 : MonoBehaviour
{
public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name = "Wave_00";
        public List<EnemyWaveList> Waves = new List<EnemyWaveList>();
        public float delay;
    }
    public List<Wave> waves = new List<Wave>();
    public List<int> Seed = new List<int>();
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public bool wavesCompleted, isWaveStarting;


    [Header("Time Between Waves")]

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Awake()
    {
        SecurityChecks();
        CreateSeed();
        for(int i = 0; i > Seed.Count; i++)
        {
            Debug.Log(Seed[i]);
        }
    }

    void Start()
    {

        waveCountdown = timeBetweenWaves;
        wavesCompleted = false;

    }
    void Update()
    {

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive() && wavesCompleted == false)
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }


        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }



    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        isWaveStarting = false;
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Count - 1 && wavesCompleted == false)
        {
            Debug.Log("ALL WAVES COMPLETE!");
            wavesCompleted = true;

        }
        else
        {
            nextWave++;
        }

    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindObjectOfType<EnemyParent>() == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave:" + _wave.name);
        state = SpawnState.SPAWNING;
        isWaveStarting = true;



        for (int i = 0; i < _wave.Waves[0].enemyList.Count; i++)
        {
            //spawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            //spawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.delay);
        }


        state = SpawnState.WAITING;

        yield break;
    }

    void spawnEnemy(EnemyFactory _enemy)
    {
        if(wavesCompleted == false)
        {
            Debug.Log("Spawning Enemy:" + _enemy.name);

            Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

            EnemyParent thisenemy = (EnemyParent)_enemy.GetProduct(new Vector2(_sp.position.x, _sp.position.y));

        }
    }





    void SecurityChecks()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn point referenced.");
        }

        if (waves.Count == 0)
        {
            Debug.LogWarning("No waves have been set up.");
        }
    }

    void CreateSeed()
    {
        for(int i = 0; i < waves.Count; i++)
        {
            int temp = Random.Range(0, waves[i].Waves.Count);
            Seed.Add(temp);
        }
    }
}
