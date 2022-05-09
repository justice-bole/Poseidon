using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;

    public void SpawnGems(GameObject objectToSpawnOn)
    {
        int random = Random.Range(0, 3);
        for (int i = 0; i < random; i++)
        {
            Instantiate(gemPrefab, objectToSpawnOn.transform.position, Quaternion.identity);
        }
    }
}
