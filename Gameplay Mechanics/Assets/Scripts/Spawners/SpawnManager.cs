using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public int range = 9;

    void Start()
    {
        double startPosX = Random.Range(-range, range);
        double startPosZ = Random.Range(-range, range);

        Instatiate(enemyPrefab, new Vector3(spawnPosZ, 1.5, spawnPosZ), enemyPrefab.transform.rotation);
    }
}
