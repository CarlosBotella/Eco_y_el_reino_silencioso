using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSwampit : MonoBehaviour
{
    GameObject Eco;
    private Attibute player1;
    private AttributeMiniSwampit enemy;
    PlayerController playerController;
     private Transform player;

     float speed1;
     public float Speed = 5;
     private bool Alert;
     public float rango;
     public LayerMask playermask;
     public bool attack;
     private float nextTime=0;
     public float AttackCooldown;
     private float speedr;
     private float attackr;

    // Start is called before the first frame update
    void Start()
    {
        Eco = GameObject.FindWithTag("Player");
        playerController = Eco.GetComponent<PlayerController>();
         player1 = Eco.GetComponent<Attibute>();
        player  = Eco.transform;
        enemy = gameObject.GetComponent<AttributeMiniSwampit>();
        speed1=Speed;
        speedr = playerController.playerSpeed;
        attackr =player1.attack;
    }

    // Update is called once per frame
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
                
                StartCoroutine(Attack());
                player1.TakeDamage(enemy.attack);
                StartCoroutine(Stop());
                nextTime = Time.time+AttackCooldown;
            }

        }
        if(Speed == 0)
        {
            StartCoroutine(Stun());
        }
    }

    public IEnumerator Stun()
     {
        Speed = 0;
        yield return new WaitForSeconds(2);
        Speed=speed1;
     }

     IEnumerator Stop()
     {
        Speed=0.01f;
        yield return new WaitForSeconds(1);
        Speed=speed1;
     }

     private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , rango);

         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z), 1);
    } 

     IEnumerator Attack()
    {
        if(player1)
        {
            float startTime=Time.time;
            //while(Time.time < startTime+ AttackCooldown )
           // {
                playerController.playerSpeed = speedr * 0.75f;
                player1.attack = attackr* 0.85f;
                yield return  new WaitForSecondsRealtime(1.5f);
                playerController.playerSpeed = speedr;
                player1.attack = attackr;
            //}
            }
    }
}
