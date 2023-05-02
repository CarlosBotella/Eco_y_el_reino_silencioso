using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mogou : MonoBehaviour
{
      GameObject Eco;
     private Attibute player1;
    private AttributesEnemies enemy;
    PlayerController playerController;
     private Transform player;
    public Transform SpawnerSwampit;
    public Transform SpawnerMiniSwampit;
    public Transform MoguAttack;
    public GameObject MiniSwampit;
    public GameObject Swampit;
    public GameObject AttackMogu;
    public float bulletSpeed;
     float speed1;
     private bool Alert;
     public float rango;
     public float rangoattack;
     public LayerMask playermask;
     public bool attack;
     private float nextTime=0;
     public float AttackCooldown;
     private float attackr;
     private float c=0;
     float vidatotal;

    private GameObject boss;
    private Image healb;
    float v= 0;

    // Start is called before the first frame update
    void Start()
    {
        Eco = GameObject.FindWithTag("Player");
        playerController = Eco.GetComponent<PlayerController>();
        player  = Eco.transform;
        player1 = Eco.GetComponent<Attibute>();
        enemy = gameObject.GetComponent<AttributesEnemies>();
        speed1=enemy.speed;
        attackr =player1.attack;
        vidatotal= enemy.heal;
        boss = GameObject.Find("ECO/Canvas/Boss");
        healb = GameObject.Find("ECO/Canvas/Boss/healBoss").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Eco)
        {
             if(v>0)
            {
                healb.fillAmount = enemy.heal/vidatotal;
            }
            Vector3 posPlayer = new Vector3(player.position.x , transform.position.y , player.position.z);
            if(enemy.heal <= vidatotal/2 && c==1)
            {
                StartCoroutine(SpawnSwampit());
                c++;
            }
            if(enemy.heal <= vidatotal*0.2 && c==2)
            {
                StartCoroutine(SpawnSwampitMiniSwampit());
                c++;
            }
        Alert = Physics.CheckSphere(transform.position, rango, playermask);
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
             if(c==0)
            {
                StartCoroutine(SpawnMiniSwampit());
                c++;
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
            var bullet = Instantiate(AttackMogu, MoguAttack.position, MoguAttack.rotation);
            bullet.GetComponent<Rigidbody>().velocity = MoguAttack.forward * bulletSpeed;
            yield return  new WaitForSecondsRealtime(1f);
        }
    }

    IEnumerator SpawnMiniSwampit()
    {
        enemy.speed = 0.1f;
        Instantiate(MiniSwampit, SpawnerMiniSwampit.position,SpawnerMiniSwampit.rotation);
        yield return  new WaitForSecondsRealtime(1f);
        enemy.speed = speed1;
    }


     IEnumerator SpawnSwampit()
    {
        enemy.speed = 0.1f;
        Instantiate(Swampit, SpawnerSwampit.position,SpawnerSwampit.rotation);
        yield return  new WaitForSecondsRealtime(1f);
        enemy.speed = speed1;
    }

     IEnumerator SpawnSwampitMiniSwampit()
    {
        enemy.speed = 0.1f;
        Instantiate(MiniSwampit, SpawnerMiniSwampit.position,SpawnerMiniSwampit.rotation);
        Instantiate(Swampit, SpawnerSwampit.position,SpawnerSwampit.rotation);
        yield return  new WaitForSecondsRealtime(1f);
        enemy.speed = speed1;
    }
}
