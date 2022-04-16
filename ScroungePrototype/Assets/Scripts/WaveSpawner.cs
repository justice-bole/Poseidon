using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private Vector3 spawnPoint;
    private bool canSpawn = true;
    private Timer timer;
    [SerializeField] private float baseSpawnRate =10;


    private void Awake()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    private void Update()
    {
        if(canSpawn)
        {
            SpawnEnemyWave();
        }
    }

    private void SpawnEnemyWave()
    {
        spawnPoint = new Vector3(Random.Range(-8, 8), Random.Range(-3.5f, 3.5f), 1);
        Instantiate(EnemyPrefab, spawnPoint, Quaternion.identity);
        StartCoroutine(EnemyWaveCDCoroutine());
    }

    private IEnumerator EnemyWaveCDCoroutine()
    {
        canSpawn = false;
        yield return new WaitForSeconds(CalculateEnemySpawnRate());
        canSpawn = true;
    }

    private float CalculateEnemySpawnRate()
    {
        float enemySpawnRate = baseSpawnRate - (timer.CurrentTime * .1f);
        float clampedSpawnRate = Mathf.Clamp(enemySpawnRate, 3, baseSpawnRate);
        print("Enemy Current Spawn Rate: " + clampedSpawnRate);
        return clampedSpawnRate;
    }
}
