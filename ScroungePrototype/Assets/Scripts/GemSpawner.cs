using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;

    public void SpawnGems(GameObject objectToSpawnOn)
    {
        int random = Random.Range(0, 10);
        if (random == 5)
        {
            Instantiate(gemPrefab, objectToSpawnOn.transform.position, Quaternion.identity);
        }
    }
}
