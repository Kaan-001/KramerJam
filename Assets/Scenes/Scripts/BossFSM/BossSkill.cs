using UnityEngine;

namespace Scenes.Scripts.BossFSM
{
    [System.Serializable]
    public abstract class BossSkill : MonoBehaviour
    {
        public string name;
        public float cooldown = 5f;
        public float duration = 2f;

        private float cooldownTimer;

        public void Init()
        {
            cooldownTimer = 0f;
        }

        public void UpdateCooldown(float deltaTime)
        {
            if (cooldownTimer > 0f)
                cooldownTimer -= deltaTime;
        }

        public bool IsReady()
        {
            return cooldownTimer <= 0f;
        }

        public virtual void Trigger()
        {
            cooldownTimer = cooldown;
            Debug.Log($"Skill used: {name}");
        }
    }
}