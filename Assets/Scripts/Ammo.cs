using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public LayerMask LayerMask;
    public void Update()
    {
        Spare();
    }
    public GameObject hitEffectPrefab;

    public void Spare()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.2f, transform.right, 0.1f, LayerMask);
        if (hit.collider != null && hit.collider.gameObject != this.gameObject)
        {
            if (hit.collider.TryGetComponent<Enemy>(out var enemy))
            {
                if (enemy != null)
                {
                    enemy.Hit(1);
                }

                // Efekti olu�tur
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

                // Mermiyi yok et
                Destroy(gameObject);
            }
            if (hit.collider.TryGetComponent<Boss>(out var boss))
            {
                if (boss != null)
                {
                    Debug.Log("Taking Damage");
                    boss.TakeDamage(1);
                }

                // Efekti olu�tur
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

                // Mermiyi yok et
                Destroy(gameObject);
            }
        }
    }
}
