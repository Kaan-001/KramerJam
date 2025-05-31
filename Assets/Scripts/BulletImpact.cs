using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    public bool hasBounced = false;
    public Rigidbody2D rb2D;
    public float speed = 10.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            if (!hasBounced)
            {
                Vector2 inDirection = rb2D.velocity;
                Vector2 normal = collision.contacts[0].normal;
                Vector2 reflectDirection = Vector2.Reflect(inDirection, normal);

                rb2D.velocity = reflectDirection.normalized * speed;
                hasBounced = true;
            }
            else
                Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
