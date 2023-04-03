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
    PlayerController playerController;
    public Transform player;
    public float Speed;
    public bool attack;
    public float KnockbackForce;
    public float KnockbackCooldown=2f;
    private float nextTime=0;
    public float KnockbackTime;
    public float heal;
    float speed1;

     void Start()
    {
            playerController = player.GetComponent<PlayerController>();
            speed1=Speed;
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

         attack = Physics.CheckSphere(transform.position, 1, playermask);
        if(attack == true && Speed != 0)
        {
           
            if (Time.time > nextTime)
            {
                
                StartCoroutine(Knockback());
                player1.TakeDamage(enemy.attack);
                StartCoroutine(Stop());
                nextTime = Time.time+KnockbackCooldown;
            }

        }
        if(Speed == 0)
        {
            StartCoroutine(Stun());
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , rango);

         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z), 1);
    } 

     IEnumerator Knockback()
    {
        if(player1)
        {
             heal=enemy.heal/20;
            float startTime=Time.time;
        while(Time.time < startTime+ KnockbackTime )
        {
            playerController.player.Move((player.transform.position-transform.position)*KnockbackForce*heal*Time.deltaTime);
        yield return null;
        }
        }
    }
    IEnumerator Stop()
     {
        Speed=0.01f;
        yield return new WaitForSeconds(1);
        Speed=speed1;
     }

     public IEnumerator Stun()
     {
        yield return new WaitForSeconds(2);
        Speed=speed1;
     }
     

     
}
