using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isKeyEquiped = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isKeyEquiped)
        {
            isKeyEquiped = true;
            Destroy(this.gameObject, 0.0f);
        }
    }
}
