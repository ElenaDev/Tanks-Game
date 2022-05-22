using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyAttack : MonoBehaviour
{
    public GameObject shellEnemyPrefab;
    public float timeBetweenAttacks;
    public Transform fireTransform;
    public float launchForce;
    public float factorLaunchForce;//factor para controlar la fuerza de lanzamiento en función de la distancia

    GameObject player;
    float timer;
    Ray ray;
    RaycastHit hit;
    float distance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        timer += Time.deltaTime;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.CompareTag("Player") && timer >= timeBetweenAttacks)
            {
                distance = hit.distance;
                Attack();//si tengo al player delante mío, le ataco
            }
        }
    }
    void Attack()
    {
        timer = 0;

        float launchForceFinal = launchForce * distance * factorLaunchForce;
        GameObject cloneShell = Instantiate(shellEnemyPrefab, fireTransform.position, fireTransform.rotation);
        cloneShell.GetComponent<Rigidbody>().velocity = fireTransform.forward * launchForceFinal;
    }
}
