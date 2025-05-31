using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField] private Player player;
    public Image healthBar;

    void Start()
    {
        GetHurt(50);
    }

    public void GetHurt(int damage)
    {
        player.health -= damage;
        healthBar.fillAmount = player.health / 100;
    }
}
