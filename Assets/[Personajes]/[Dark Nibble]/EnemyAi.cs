using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;    

public class EnemyAi : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask IsGround, IsPlayer;

    public Vector3 walkingPoint;
    bool walkingPointSet;
    public float walkingPointRange;

    public float va;
    bool aa;

    public float range, attackrange;
    public bool playerrange, playerattackrange;

    private void Awake()
    {
        player = GameObject.Find("ECO").transform;
        agent = GetComponent<NavMeshAgent>();
    } 

    private void Update()
    {
        playerrange = Physics.CheckSphere(transform.position, range, IsPlayer);
        playerattackrange = Physics.CheckSphere(transform.position, attackrange, IsPlayer);
        if(!playerrange && !playerattackrange) Patroling();
        if(playerrange && !playerattackrange) Chase();
        if(playerrange && playerattackrange) Attack();
        
    }

    private void Patroling()
    {
        if(!walkingPointSet) SearchWalkPoint();

        if(walkingPointSet)
            agent.SetDestination(walkingPoint);

        Vector3 distanceToWalkPoint = transform.position - walkingPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkingPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkingPointRange, walkingPointRange);
        float randomX = Random.Range(-walkingPointRange, walkingPointRange);
        
        walkingPoint = new Vector3(transform.position.x +randomX , transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkingPoint, -transform.up, 2f, IsGround))
            walkingPointSet = true;
    }
    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        
    }


    private  void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position , range);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , attackrange);
    }
}
