using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepSeaKing : MonoBehaviour
{
    
   GameObject Eco;
    private Attibute player1;
    private AttributesEnemies enemy;
    PlayerController playerController;
     private Transform player;
    public float rango;
    public float kr;
    public LayerMask playermask;
    private bool Alert;
    public bool attack;
    private float nextTime=0;
    private float nextTimeTorbellino=0;
    public float Attackspeed;
    float speed1;
    public GameObject torbellino;
    public Transform TorbellinoSpawner;
    public float nextTorbellino;
    float healt;
    public float randomx;
    public float randomz;
        
    

     void Start()
    {
        Eco = GameObject.FindWithTag("Player");
        playerController = Eco.GetComponent<PlayerController>();
        player1 = Eco.GetComponent<Attibute>();
        player  = Eco.transform;
        enemy = gameObject.GetComponent<AttributesEnemies>();
        speed1=enemy.speed;
        healt = enemy.heal;
        
    }

    void Update()
    {
        Alert = Physics.CheckSphere(transform.position, rango, playermask);
        if(Alert == true && !attack)
        {
            Vector3 posPlayer = new Vector3(player.position.x , transform.position.y , player.position.z);
            transform.LookAt(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, enemy.speed * Time.deltaTime );
              if(Time.time > nextTimeTorbellino)
                {
                    TorbellinoSpawner.position = player.position+new Vector3(Random.Range(-randomx,randomx),TorbellinoSpawner.position.y-1,Random.Range(-randomz,randomz));
                     TorbellinoSpawner.position= new Vector3( TorbellinoSpawner.position.x,0, TorbellinoSpawner.position.z);
                    Instantiate(torbellino,  TorbellinoSpawner.position,TorbellinoSpawner.rotation);
                    nextTimeTorbellino = Time.time+nextTorbellino;
                }
        }

         attack = Physics.CheckSphere(new Vector3(transform.position.x,transform.position.y-2,transform.position.z), kr, playermask);
        if (attack == true && enemy.speed != 0.5f)
        {
            if (Time.time > nextTime)
            {
                if(enemy.heal <= healt * 0.2)
                {
                    player1.TakeDamage(200f);
                    StartCoroutine(Stop());
                    nextTime = Time.time+Attackspeed;
                }
                else
                {
                player1.TakeDamage(enemy.attack);
                StartCoroutine(Stop());
                nextTime = Time.time+Attackspeed;
                }
            }
        }
        if(enemy.speed == 0)
        {
            StartCoroutine(Stun());
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rango);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, kr);
    } 

    IEnumerator Stop()
     {
        enemy.speed=0.5f;
        yield return new WaitForSeconds(1);
        enemy.speed=speed1;
     }

     public IEnumerator Stun()
     {
        float heal3=enemy.heal;
        if(enemy.heal<heal3)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2);
        enemy.speed=speed1;
     }

}
