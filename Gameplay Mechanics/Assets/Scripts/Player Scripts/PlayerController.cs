using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // globally declaring all required variables, that includes 

    public float speed = 5f;

    private Rigidbody PlayerRb;
    private GameObject FocalPoint;

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
    }
}
