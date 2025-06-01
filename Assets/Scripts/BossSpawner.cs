using System;
using UnityEngine;

namespace Scenes.Scripts
{
    public class BossSpawner : MonoBehaviour
    {
        public static BossSpawner instance;
        
        public GameObject bossPrefab;
        public Vector2 bossSpawnPoint;
        public int deathThreshold;
    
        private int currentDeathCount;
        private bool isBossSpawned;

        private void Awake()
        {
            if (instance != null && instance != this) 
            { 
                Destroy(this);
                return;
            } 
            instance = this;
        }

        public void OnEnemyDeath()
        {
            if (isBossSpawned) { return; }
            currentDeathCount++;
            Debug.Log("Boss spawned: " + currentDeathCount);
            if (currentDeathCount >= deathThreshold)
            {
                Debug.Log("Boss spawned");
                Instantiate(bossPrefab, bossSpawnPoint, Quaternion.identity);
                isBossSpawned = true;
            }
        }
    }
}
