using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider slider;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("ShellEnemy"))
        {
            TakeDamage(collision.collider.GetComponent<Shell>().damageEnemy);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        slider.value = currentHealth;

        if (currentHealth <= 0) Death();
    }

    void Death()
    {
        gameManager.GameOver();
    }

}
