using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TankEnemyMovement : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;
        agent.SetDestination(player.transform.position);
    }
}
