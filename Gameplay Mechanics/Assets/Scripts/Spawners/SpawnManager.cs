using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpIndicator;
    public GameObject powerUpPrefab;
    
    public int range = 9;

    public bool hasPowerUp = false;

    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        spawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
    }

    void Update(){
        powerUpIndicator.transform.position += new Vector3(0, -1.5f, 0);

        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount <= 0){
            spawnEnemyWave(waveNumber);
            waveNumber++;
            Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
        }

        if(transform.position.y <= (-10)){
            Destroy(gameObject);
        }
    }

    private Vector3 GenerateSpawnPos(){
        float spawnPosX = Random.Range(-range, range);
        float spawnPosZ = Random.Range(-range, range);

        Vector3 spawnPos = new Vector3(spawnPosX, 0f, spawnPosZ);

        return spawnPos;
    }

    private void spawnEnemyWave(int enemysToSpawn){
        for(int i = 0; i < enemysToSpawn; i++){
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
