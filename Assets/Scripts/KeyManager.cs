using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject key;
    private bool isKey = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            isKey = true;
        }
    }
}
