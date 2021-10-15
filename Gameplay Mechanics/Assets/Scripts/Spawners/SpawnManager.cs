using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpIndicator;
    
    public int range = 9;

    public bool hasPowerUp = false;

    void Start()
    {
        spawnEnemyWave(3);
    }

    void Update(){
        powerUpIndicator.transform.position += new Vector3(0, -1.5f, 0);
    }

    private Vector3 GenerateSpawnPos(){
        float spawnPosX = Random.Range(-range, range);
        float spawnPosZ = Random.Range(-range, range);

        Vector3 spawnPos = new Vector3(spawnPosX, 1.5f, spawnPosZ);

        return spawnPos;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Power Up")){
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountdownRountine());
            powerUpIndicator.gameObject.SetActive(true);
        }
        else{
            hasPowerUp = false;
        }
    }

    IEnumerator powerUpCountdownRountine(){
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void spawnEnemyWave(int enemysToSpawn){
        for(int i = 0; i < enemysToSpawn; i++){
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
