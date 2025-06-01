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
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Hit(1);
            }

            // Efekti oluþtur
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

            // Mermiyi yok et
            Destroy(gameObject);
        }
    }
}
