using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float baseSpawnRate = 7;
    [SerializeField ]private GameObject EnemyPrefab;
   
    private bool canSpawn = true;
    private Timer timer;
    private Vector3 spawnPoint;
    
    private void Awake()
    {
        timer = GameObject.Find("TimerText").GetComponent<Timer>();
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
        SetSpawnPoint();
        Instantiate(EnemyPrefab, spawnPoint, Quaternion.identity);
        StartCoroutine(EnemyWaveCDCoroutine());
    }

    private void SetSpawnPoint()
    {
        spawnPoint = new Vector3(Random.Range(-8, 8), Random.Range(-3.5f, 3.5f), 1);
    }

    private IEnumerator EnemyWaveCDCoroutine()
    {
        canSpawn = false;
        yield return new WaitForSeconds(CalculateEnemySpawnRate());
        canSpawn = true;
    }

    private float CalculateEnemySpawnRate()
    {
        float enemySpawnRate = baseSpawnRate - (timer.CurrentTime * .05f);
        float clampedSpawnRate = Mathf.Clamp(enemySpawnRate, 2, baseSpawnRate);
        //print("Enemy Current Spawn Rate: " + clampedSpawnRate);
        return clampedSpawnRate;
    }
}
