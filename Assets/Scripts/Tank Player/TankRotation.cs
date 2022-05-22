using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRotation : MonoBehaviour
{
    public int turnSpeed = 5;
    public Transform ob;//Torreta del tanque, est� como hijo
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        //giro la torreta con el input
        ob.Rotate(Vector3.up * 40 * Time.deltaTime * h);

        if (Input.GetKey(KeyCode.P)) Turn();
        if (Input.GetKeyUp(KeyCode.P)) ob.SetParent(this.transform);
    }
    void Turn()
    {
        ob.SetParent(null);
        //Creo una rotaci�n en base al eje Z de la torreta
        Quaternion rot = Quaternion.LookRotation(ob.forward);
        //Giro el tanque para que se alinee con la torreta, lo que estamos
        //haciendo es
        //alinear el Z del tanque con el Z de la torreta
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 
            turnSpeed * Time.deltaTime);
    }
}
