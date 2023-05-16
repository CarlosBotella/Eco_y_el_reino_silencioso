using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
 public Transform[] ruta;

    NavMeshAgent agent;

    int nextPoint = 0;


     void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update(){
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            nextPoint++;
            agent.SetDestination(ruta[nextPoint % ruta.Length].position);
        }
    }
}
