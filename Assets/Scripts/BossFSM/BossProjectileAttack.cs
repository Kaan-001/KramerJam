using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.Scripts.BossFSM
{
    public class BossProjectileAttack : BossSkill
    {
        public override void Trigger()
        {
            base.Trigger();
            FireProjectiles();
        }
        
        private void FireProjectiles()
        {
            float angleStep = 360f / projectileCount;
            float radius = 0.1f; // Opsiyonel: boss'un merkezinden biraz dışarıdan başlatmak için

            for (int i = 0; i < projectileCount; i++)
            {
                float angle = i * angleStep;
                float angleRad = angle * Mathf.Deg2Rad;

                // Yön vektörü (2D: X ve Y düzleminde)
                Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized;

                // Spawn pozisyonu: merkezin biraz dışında
                Vector2 spawnPos = (Vector2)transform.position + direction * radius;

                BossProjectile proj = Instantiate(bossProjectile, spawnPos, Quaternion.identity).GetComponent<BossProjectile>();
                proj.SetDirection(direction); // Projectile kendi yönüne ilerleyecek
                proj.isActive = true;
            }
        }
    }
}
