using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankEnemyHealth : MonoBehaviour
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
        if (collision.collider.CompareTag("ShellPlayer"))//si la bala del player entra en colisión con el enemigo
        {
            //quito vida al enemigo y miro a través del componente Shell (Script) cuanta vida le quito
            TakeDamage(collision.collider.GetComponent<Shell>().damagePlayer);
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
        gameManager.AddEnemyUI();
        Destroy(gameObject);
    }
}
