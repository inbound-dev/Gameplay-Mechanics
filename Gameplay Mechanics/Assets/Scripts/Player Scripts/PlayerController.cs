using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // globally declaring all required variables, that includes 

    public float speed = 5f;
    private float powerUpStrength = 15f;

    private Rigidbody PlayerRb;
    private GameObject FocalPoint;

    public GameObject enemyPrefab;
    public GameObject powerUpIndicator;
    public GameObject powerUpPrefab;

    public bool hasPowerUp = false;

    public SpawnManager spawnManager;

    // the void start function is used on run event and only executes once
    void Start()
    {
        // finding components of and entire game objects
        PlayerRb = GetComponent<Rigidbody>();   
        FocalPoint = GameObject.Find("Focal Point");
    }

    // the void update function is called continuosly (every frame)
    void Update()
    {
        // getting user input and applying it to the player object
        float forwardInput = Input.GetAxis("Vertical");
        PlayerRb.AddForce(FocalPoint.transform.forward * forwardInput * speed);

        spawnManager = GameObject.Find("Player").GetComponent<SpawnManager>();

        if(gameObject.transform.position.y <= -10){
            //Destroy(gameObject);
            Debug.Log("GameOver!");
        }
        
    }

    private void OnCollisionEnter(Collision collision){

        Debug.Log(hasPowerUp);

        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp == true){

            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

           Debug.Log("Collided with " + collision.gameObject.name + " With PowerUp Set to " + hasPowerUp);

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
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
            powerUpIndicator.gameObject.SetActive(false);
        }
    }

    IEnumerator powerUpCountdownRountine(){
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}
