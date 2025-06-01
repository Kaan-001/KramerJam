using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace BossFSM
{
    public class AoeZone : MonoBehaviour
    {
        public float explosionRadius = 2.5f;
        public float damage = 10f;
        public GameObject warningEffect;
        public GameObject explosionEffect;

        private float focusTime;

        public void Initialize(float focusDuration)
        {
            focusTime = focusDuration;
            StartCoroutine(ActivateExplosion());
        }

        private IEnumerator ActivateExplosion()
        {
            // Odak animasyonu oynat (örneğin kırmızı halka büyüsün)
            if (warningEffect != null)
                warningEffect.SetActive(true);

            yield return new WaitForSeconds(focusTime);

            if (warningEffect != null)
                warningEffect.SetActive(false);

            if (explosionEffect != null)
                Instantiate(explosionEffect, transform.position, Quaternion.identity);

            // Hasar ver
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            foreach (var hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    HealthHandle health = FindObjectOfType(typeof(HealthHandle)).GetComponent<HealthHandle>();
                    health.GetHurt(damage);
                }
            }

            Destroy(gameObject);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}