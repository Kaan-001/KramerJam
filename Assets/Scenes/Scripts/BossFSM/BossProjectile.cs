using UnityEngine;

namespace Scenes.Scripts.BossFSM
{
    public class BossProjectile : MonoBehaviour
    {
        public float speed = 5f;
        public float lifetime = 5f;
        public bool isActive;

        private Vector3 direction;

        public void SetDirection(Vector3 dir)
        {
            direction = dir.normalized;
            Destroy(gameObject, lifetime);
        }

        void Update()
        {
            if (!isActive) { return; }
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
