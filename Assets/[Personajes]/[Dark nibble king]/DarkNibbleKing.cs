using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class DarkNibbleKing : MonoBehaviour
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
    public float KnockbackForce;
    public float KnockbackCooldown=2f;
    private float nextTime=0;
    public float KnockbackTime;
    public float heal;
    float speed1;
    private GameObject boss;
    private Image healb;
    private Text text;
     float vidatotal;
     public Transform punto;
     NavMeshAgent agent;

     private Animator animator;
      private Animator animator2;
    

     void Start()
    {
        Eco = GameObject.FindWithTag("Player");
        playerController = Eco.GetComponent<PlayerController>();
        player1 = Eco.GetComponent<Attibute>();
        player  = Eco.transform;
        enemy = gameObject.GetComponent<AttributesEnemies>();
        speed1=enemy.speed;
        boss = GameObject.Find("ECO/Canvas/Boss");
        healb = GameObject.Find("ECO/Canvas/Boss/healBoss").GetComponent<Image>();
        text = GameObject.Find("ECO/Canvas/Boss/nombre").GetComponent<Text>();
        vidatotal= enemy.heal;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator2 = Eco.GetComponent<Animator>();
    }

    void Update()
    {
        if(Eco)
        {   
            Alert = Physics.CheckSphere(transform.position, rango, playermask);
            if(Alert && enemy.heal>0)
            {
                boss.SetActive(true);
                healb.fillAmount = enemy.heal/vidatotal;
                text.text = transform.tag;
                animator.SetBool("Alert",true);
            }
            if(!Alert)
            {
                boss.SetActive(false);
                transform.position = Vector3.MoveTowards(transform.position, punto.transform.position, enemy.speed * Time.deltaTime);
                animator.SetBool("Alert",false);
            }
        if(Alert == true && !attack && enemy.heal>0)
        {
            Vector3 posPlayer = new Vector3(player.position.x , transform.position.y , player.position.z);
            transform.LookAt(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, enemy.speed * Time.deltaTime);
        }

         attack = Physics.CheckSphere(new Vector3(transform.position.x,transform.position.y+1,transform.position.z), kr, playermask);
        if (attack == true && enemy.speed > 0.5f)
        {
            if (Time.time > nextTime)
            {
                animator.SetTrigger("Attack");
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
        Gizmos.DrawWireSphere(transform.position, rango);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y+1,transform.position.z), kr);
    } 

     IEnumerator Knockback()
    {
        if(Eco)
        {
            animator2.SetTrigger("KnockBack");
             heal = 1-enemy.heal/140;
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

     
        private void OnAnimatorMove() {
        
    }

}
