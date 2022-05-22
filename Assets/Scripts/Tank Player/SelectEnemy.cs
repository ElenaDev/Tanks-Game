using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEnemy : MonoBehaviour
{
    public Slider tankEnemyHealthUI;

    TankEnemyHealth tankEnemyHealth;
    TankMovement tankMovement;

    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        tankMovement = GetComponent<TankMovement>();
        tankEnemyHealthUI.gameObject.SetActive(false);
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(1))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                //¿Esta el slider activo en la escena?
                if (!tankEnemyHealthUI.gameObject.activeInHierarchy)
                {
                    tankEnemyHealth = hit.collider.GetComponent<TankEnemyHealth>();
                    tankEnemyHealthUI.gameObject.SetActive(true);
                    tankEnemyHealthUI.maxValue = tankEnemyHealth.maxHealth;
                    tankEnemyHealthUI.GetComponent<SliderEnemy>().tankEnemyHealth = tankEnemyHealth;                   
                }
                tankMovement.TurnToTarget(hit.point);

            }
            else tankEnemyHealthUI.gameObject.SetActive(false);
        }
    }
}
