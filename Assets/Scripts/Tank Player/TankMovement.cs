using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    float horizontal;
    float vertical;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        /*transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontal);*/
    }
    void FixedUpdate()
    {
        Move();
        Turn();
    }
    void Move()
    {
        Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }
    void Turn()
    {
        float turn = horizontal * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * turnRotation);
    }
    public void TurnToTarget(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.y = 0;
        Quaternion rot = Quaternion.LookRotation(direction);
        transform.rotation = rot;
    }
}
