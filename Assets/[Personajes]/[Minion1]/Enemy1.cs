using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Attibute player1;
    public Attributeenemy1 enemy;
    public float rango;
    public LayerMask playermask;
    private bool Alert;

    public PlayerController playercontroller;
    public Transform player;
    public float Speed;
    public bool attack;
    public float KnockbackForce;

     void Start()
    {
        playercontroller = GetComponent<PlayerController>();

    }
    void Update()
    {
        Alert = Physics.CheckSphere(transform.position, rango, playermask);
        if(Alert == true)
        {
            Vector3 posPlayer = new Vector3(player.position.x , transform.position.y , player.position.z);
            transform.LookAt(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, Speed * Time.deltaTime );
        }

         attack = Physics.CheckSphere(transform.position, 2, playermask);
        if(attack == true)
        {
            Knockback();
            //player1.TakeDamage(enemy.attack);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rango);

         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);
    } 

     void Knockback()
    {
        //player1.transform.position += transform.forward * Time.deltaTime * KnockbackForce;
        playercontroller.player.Move(transform.forward *KnockbackForce*Time.deltaTime);
        print(player1.attack);
    }
     
}
