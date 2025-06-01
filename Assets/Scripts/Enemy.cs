using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    public AIDestinationSetter DestinationSetter;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DestinationSetter.target = player;
    }

    void Update()
    {
        FlipTowardsPlayer();
    }

    void FlipTowardsPlayer()
    {
        if (player == null) return;

        float diff = player.position.x - transform.position.x;

        if (diff > 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Saða bak
        }
        else if (diff < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Sola bak
        }
    }
}
