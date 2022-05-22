using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public Rigidbody shellPrefab;
    public Transform fireTransform;
    public float launchForce;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Launch();
    }
    void Launch()
    {
        Rigidbody cloneShell = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation) as Rigidbody; 
        cloneShell.velocity = fireTransform.forward * launchForce;
    }
}
