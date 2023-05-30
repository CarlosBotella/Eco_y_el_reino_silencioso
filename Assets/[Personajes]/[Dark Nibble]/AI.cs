using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
 public Transform[] ruta;

    NavMeshAgent agent;

    int nextPoint = 0;  
    DarkNibble darkNibble;

     void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        darkNibble = GetComponent<DarkNibble>();
    }
    void Update(){
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !darkNibble.Attack2)
        {
            nextPoint++;
            agent.SetDestination(ruta[nextPoint % ruta.Length].position);
        }
    }
}
