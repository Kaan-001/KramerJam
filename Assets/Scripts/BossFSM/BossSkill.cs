using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scenes.Scripts.BossFSM
{
    [System.Serializable]
    public abstract class BossSkill : MonoBehaviour
    {
        public string skillName;
        public float cooldown;
        public float duration;
        public int projectileCount;
        public GameObject bossProjectile;
        public GameObject player;

        private float cooldownTimer;

        public void Init()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            cooldownTimer = cooldown;
        }

        void Update()
        {
            if (cooldownTimer > 0f)
                cooldownTimer -= Time.deltaTime;
        }

        public bool IsReady()
        {
            Debug.Log($"Skill: {skillName} - Cooldown: {cooldownTimer}");
            return cooldownTimer <= 0f;
        }

        public virtual void Trigger()
        {
            cooldownTimer = cooldown;
            Debug.Log($"Skill used: {skillName}");
        }
    }
}