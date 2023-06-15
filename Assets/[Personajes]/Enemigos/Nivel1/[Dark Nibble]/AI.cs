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
    private AttributesEnemies attributesEnemies;
     void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        darkNibble = GetComponent<DarkNibble>();
        attributesEnemies = GetComponent<AttributesEnemies>();
    }
    void Update(){
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !darkNibble.Attack2 && attributesEnemies.speed !=0)
        {
            nextPoint++;
            agent.SetDestination(ruta[nextPoint % ruta.Length].position);
        }
    }
}
