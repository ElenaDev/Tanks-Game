using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public int damageEnemy;
    public int damagePlayer;

    private void Start()
    {
        Destroy(gameObject, 3);
    }
}
