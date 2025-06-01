using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")&&Key.isKeyEquiped) 
        {
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Key.isKeyEquiped = false;
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
