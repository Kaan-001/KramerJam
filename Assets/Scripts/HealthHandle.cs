using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthHandle : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField] private Player player;
    public Image healthBar;
    public GameObject deathScreen;

    public void GetHurt(float damage)
    {
        player.health -= damage;
        healthBar.fillAmount = player.health / 100;
        Die();
    }

    public void GetHP(float hp)
    {
        healthBar.fillAmount += hp / 100;
    }

    public void Die()
    {
        if (deathScreen != null && player.health <= 0)
        {
            deathScreen.SetActive(true);

            Time.timeScale = 0f; // Oyunu durdur
            StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
