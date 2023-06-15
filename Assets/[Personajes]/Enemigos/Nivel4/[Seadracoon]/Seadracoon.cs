using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Seadracoon: MonoBehaviour
{
   GameObject Eco;
    private Attibute player1;
    private AttributesEnemies enemy;
    PlayerController playerController;
     private Transform player;

     float speed1;
     private bool Alert;
     public float rango;
     public LayerMask playermask;
     public bool attack;
     private float nextTime=0;
     public float AttackCooldown;
     private float nextTimeHeal = 0; 
     public float nextHeal;
     private float theal;
     public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        Eco = GameObject.FindWithTag("Player");
        playerController = Eco.GetComponent<PlayerController>();
         player1 = Eco.GetComponent<Attibute>();
        player  = Eco.transform;
        enemy = gameObject.GetComponent<AttributesEnemies>();
        speed1=enemy.speed;
        theal = enemy.heal;

    }

    // Update is called once per frame
    void Update()
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
                player1.TakeDamage(enemy.attack);
                StartCoroutine(Stop());
                nextTime = Time.time+AttackCooldown;
            }

        }

        Vector3 direction = Vector3.down;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction*1));
        if(Physics.Raycast(theRay, out RaycastHit hit, 1,layerMask))
        {
            enemy.speed = 9;
            if (Time.time > nextTimeHeal)
            {
                    enemy.speed = 9;
                    enemy.heal = enemy.heal + 5;
                    if(enemy.heal > theal)
                    {
                        enemy.heal = theal;
                    }
                nextTimeHeal = Time.time+nextHeal;
            }
        }

        if( enemy.speed == 0 )
        {
            StartCoroutine(Stun());
        }

    }

    public IEnumerator Stun()
     {
        enemy.speed = 0;
        yield return new WaitForSeconds(2);
        enemy.speed=speed1;
     }

     IEnumerator Stop()
     {
        enemy.speed=0.01f;
        yield return new WaitForSeconds(1);
        enemy.speed=speed1;
     }

     private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , rango);

         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z), 1);
    } 

}
