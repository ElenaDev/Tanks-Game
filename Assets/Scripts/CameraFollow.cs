using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 posCamera = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, posCamera, smoothing * Time.deltaTime);
    }
}
