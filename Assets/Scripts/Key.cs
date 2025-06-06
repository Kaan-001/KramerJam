using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool isKeyEquiped = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isKeyEquiped)
        {
            isKeyEquiped = true;
            Destroy(this.gameObject, 0.0f);
        }
    }
}
