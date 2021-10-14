using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private GameObject player;
    private Rigidbody EnemyRb;

    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Vector3 lookDir = (player.transform.position - transform.position).normalized;
        EnemyRb.AddForce(lookDir * speed);
    }
}
