using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public static Action onEnemyDeath;
    public Vector2 bossSpawnPoint;
    public int deathThreshold;
    
    private int currentDeathCount;
    
    private void Start()
    {
        onEnemyDeath += OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        currentDeathCount++;
        if (currentDeathCount >= deathThreshold)
        {
            // Spawn boss
            Debug.Log("Boss spawned");
        }
    }
}
