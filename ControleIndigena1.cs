using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ControleIndigena1 : MonoBehaviour
{

    public Transform Player;
    public NavMeshAgent agent;
    public Vector3 destination;

    void FixedUpdate()
    {

        destination = Player.transform.position;
        agent.SetDestination(destination);
    }

}
