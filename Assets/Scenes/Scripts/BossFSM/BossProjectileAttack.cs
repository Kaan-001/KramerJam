using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.Scripts.BossFSM
{
    public class BossProjectileAttack : BossSkill
    {
        public int projectileCount;
        public BossProjectile bossProjectile;
        
        public override void Trigger()
        {
            base.Trigger();
            FireProjectiles();
        }
        
        private void FireProjectiles()
        {
            float angleStep = 360f / projectileCount;

            for (int i = 0; i < projectileCount; i++)
            {
                float angle = i * angleStep;
                Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                BossProjectile proj = Instantiate(bossProjectile, transform.position, Quaternion.identity);
                proj.SetDirection(direction);
                proj.isActive = true;
            }
        }
    }
}
