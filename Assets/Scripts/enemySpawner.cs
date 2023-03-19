using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public EnemyFactory[] enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    //public floatVariable countdownUI;
    public boolVariable wavesCompleted, isWaveStarting;


    [Header("Time Between Waves")]

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn point referenced.");
        }
        waveCountdown = timeBetweenWaves;
        wavesCompleted.boolValue = false;

    }
    void Update()
    {

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
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
            //countdownUI.floatValue = waveCountdown;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("ALL WAVES COMPLETE!");
            wavesCompleted.boolValue = true;

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



        for (int i = 0; i < _wave.count; i++)
        {
            spawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            //spawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }


        state = SpawnState.WAITING;

        yield break;
    }

    void spawnEnemy(EnemyFactory _enemy)
    {
        Debug.Log("Spawning Enemy:" + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        EnemyParent thisenemy = (EnemyParent)_enemy.GetProduct(new Vector2(_sp.position.x, _sp.position.y));
    }

}


