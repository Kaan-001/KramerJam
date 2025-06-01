using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private Player player;
    private HealthHandle healthSlider;
    public float healthAward = 10;
    public float currentHealth;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        healthSlider = GameObject.FindObjectOfType<HealthHandle>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.health += healthAward;
            healthSlider.GetHP(healthAward);
            Destroy(this.gameObject, 0.0f);
        }
    }
}
