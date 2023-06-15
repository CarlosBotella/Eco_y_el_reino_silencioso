using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nyx : MonoBehaviour
{
   GameObject Eco;
    private Attibute player1;
    private AttributesEnemies enemy;
    PlayerController playerController;
     private Transform player;

     float speed1;
     private bool Alert;
     public float rango;
     public float rangoattack;
     public LayerMask playermask;
     public bool attack;
     private float nextTime=0;
     public float AttackCooldown;
     private float healt;

    public float bulletSpeed;
    public Transform spawnAttack;
    public GameObject AttackNyx;

    public GameObject vipernox;
    public float spawncooldown;
    private float newxtvipernox=0;
    public Transform spawnvipernox;
    private float nextHabilidad = 12;
    private float HabilidadCast = 2;
     private float nextTimeHabilidad = 0;
     private float dmgHabilidad = 35;
     private GameObject boss;
    private Image healb;
    float v= 0;
    

    


    // Start is called before the first frame update
    void Start()
    {
        Eco = GameObject.FindWithTag("Player");
        playerController = Eco.GetComponent<PlayerController>();
         player1 = Eco.GetComponent<Attibute>();
        player  = Eco.transform;
        enemy = gameObject.GetComponent<AttributesEnemies>();
        speed1=enemy.speed;
        healt = enemy.heal;
        boss = GameObject.Find("ECO/Canvas/Boss");
        healb = GameObject.Find("ECO/Canvas/Boss/healBoss").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Eco)
        {
            Vector3 posPlayer = new Vector3(player.position.x , transform.position.y , player.position.z);
            Alert = Physics.CheckSphere(transform.position, rango, playermask);
            if(v>0)
            {
                healb.fillAmount = enemy.heal/healt;
            }
            if(Alert)
            {
             if(v==0)
            {
                boss.SetActive(true);
                v++;
            }
            }
            if(Alert == true && attack !=true)
            {
                transform.LookAt(posPlayer);
                transform.position = Vector3.MoveTowards(transform.position, posPlayer, enemy.speed * Time.deltaTime );
                
            }
            if(Alert == true)
            {
                if(Time.time > newxtvipernox)
                {
                    Instantiate(vipernox,spawnvipernox.position,spawnvipernox.rotation);
                    newxtvipernox = Time.time+   spawncooldown; 
                }
                if(enemy.heal <= healt*0.3)
                {
                    if(Time.time > nextTimeHabilidad)
                    {
                        StartCoroutine(Habiliad());
                        nextTimeHabilidad = Time.time + nextHabilidad;
                    }
                }
            }

            attack = Physics.CheckSphere(transform.position, rangoattack, playermask);
            if(attack == true && enemy.speed != 0) 
            {
                transform.LookAt(posPlayer);
                if (Time.time > nextTime)
                {
                    StartCoroutine(Attack());
                    StartCoroutine(Stop());
                    nextTime = Time.time+AttackCooldown;
                }

            }
            if(enemy.speed == 0)
            {
                StartCoroutine(Stun());
            }
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
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z), rangoattack);
    } 
        

     IEnumerator Attack()
    {
        if(player1)
        {
            var bullet = Instantiate(AttackNyx, spawnAttack.position, spawnAttack.rotation);
            bullet.GetComponent<Rigidbody>().velocity = spawnAttack.forward * bulletSpeed;
            yield return  new WaitForSecondsRealtime(1f);
        }
    }

    IEnumerator Habiliad()
    {
        bool Habilidadr = Physics.CheckSphere(transform.position,20,playermask);
        float startTime=Time.time;
        enemy.speed = 0;
        yield return new WaitForSeconds(HabilidadCast);
        if(Habilidadr)
        {
            player1.TakeDamage(dmgHabilidad);
        }
        enemy.speed = speed1;
        yield return null;
        
    }
}
