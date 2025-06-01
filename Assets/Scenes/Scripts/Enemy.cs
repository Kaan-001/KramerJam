using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    public AIDestinationSetter DestinationSetter;
    public GameObject player;
    private int damage = 2;
    private int maxHealth = 2;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        DestinationSetter.target = player.transform;
    }

    void Update()
    {
        FlipTowardsPlayer();
    }

    void FlipTowardsPlayer()
    {
        if (player == null) return;

        float diff = player.transform.position.x - transform.position.x;

        if (diff > 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Saða bak
        }
        else if (diff < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Sola bak
        }
    }

    public void Hit(int hit)
    {
        currentHealth -= hit;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
