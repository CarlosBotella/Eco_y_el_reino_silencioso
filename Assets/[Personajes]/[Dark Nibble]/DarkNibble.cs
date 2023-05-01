using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkNibble : MonoBehaviour
{
     GameObject Eco;
    private Attibute player1;
    private AttributesEnemies enemy;
    PlayerController playerController;
     private Transform player;
    public float rango;
    public LayerMask playermask;
    private bool Alert;
    public bool attack;
    public float KnockbackForce;
    public float KnockbackCooldown=2f;
    private float nextTime=0;
    public float KnockbackTime;
    public float heal;
    float speed1;

     void Start()
    { 
        Eco = GameObject.FindWithTag("Player");
        playerController = Eco.GetComponent<PlayerController>();
        player1 = Eco.GetComponent<Attibute>();
        player  = Eco.transform;
        enemy = gameObject.GetComponent<AttributesEnemies>();
        speed1 = enemy.speed;
    }

    void Update()
    {
        if(Eco)
        {

            Alert = Physics.CheckSphere(transform.position, rango, playermask);
        if(Alert == true && !attack)
        {
            Vector3 posPlayer = new Vector3(player.position.x , transform.position.y , player.position.z);
            transform.LookAt(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, enemy.speed * Time.deltaTime );
        }

         attack = Physics.CheckSphere(transform.position, 1, playermask);
        if(attack == true && enemy.speed != 0)
        {
            if (Time.time > nextTime)
            {
                
                StartCoroutine(Knockback());
                player1.TakeDamage(enemy.attack);
                StartCoroutine(Stop());
                nextTime = Time.time+KnockbackCooldown;
            }

        }
        if(enemy.speed == 0)
        {
            StartCoroutine(Stun());
        }
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
        if(Eco)
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
        enemy.speed=0.01f;
        yield return new WaitForSeconds(1);
        enemy.speed=speed1;
     }

     public IEnumerator Stun()
     {
        yield return new WaitForSeconds(2);
        enemy.speed=speed1;
     }


     
}
