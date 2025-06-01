using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box") || collision.collider.CompareTag("Boss"))
        {
            Destroy(this.gameObject);
        }
    }
}