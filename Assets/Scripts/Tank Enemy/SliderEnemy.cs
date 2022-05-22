using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEnemy : MonoBehaviour
{
    public TankEnemyHealth tankEnemyHealth;

    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (tankEnemyHealth != null) slider.value = tankEnemyHealth.currentHealth;
        else slider.gameObject.SetActive(false);
    }
}
