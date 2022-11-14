using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private int oneInXChanceToSpawn;

    public void SpawnGems(GameObject objectToSpawnOn)
    {
        int random = Random.Range(0, oneInXChanceToSpawn);
        if (random == oneInXChanceToSpawn % 2)
        {
            Instantiate(gemPrefab, objectToSpawnOn.transform.position, Quaternion.identity);
        }
    }
}
 