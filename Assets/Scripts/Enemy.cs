using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    public GameObject KeyDoor;
    public HealthHandle healthHandle;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        healthHandle = GameObject.FindAnyObjectByType<HealthHandle>();
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
            transform.localScale = new Vector3(-1f, 1f, 1f); // Sa�a bak
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
            if(KeyDoor != null) 
            {
                GameObject spawnedObj = Instantiate(KeyDoor, transform.position, Quaternion.identity);

                Vector2 randomOffset = new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 2f));
                Vector3 jumpTarget = transform.position + (Vector3)randomOffset;

                spawnedObj.transform.DOJump(jumpTarget, 1.5f, 1, 0.5f).SetEase(Ease.OutQuad);
            }
            BossSpawner.onEnemyDeath.Invoke();
            // D��man �lme efekti yapabilirsin destroy olur ama �ncesinde efekti instantiate eder ve efekt kapan�r
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthHandle.GetHurt(10f);
            healthHandle.Die();
        }
    }
}
