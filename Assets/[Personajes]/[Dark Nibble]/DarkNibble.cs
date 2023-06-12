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
    public bool Attack2=false;
    private Animator animator;
    private Animator animator2;
    public GameObject stars;

    public AudioClip audioClip1; // Nueva variable para el AudioClip
    public AudioClip audioClip2; // Nueva variable para el AudioClip
    public GameObject objetoReproductor2;
    private bool alert2 = false;


     void Start()
    { 
        Eco = GameObject.FindWithTag("Player");
        playerController = Eco.GetComponent<PlayerController>();
        player1 = Eco.GetComponent<Attibute>();
        player  = Eco.transform;
        enemy = gameObject.GetComponent<AttributesEnemies>();
        speed1 = enemy.speed;
        animator = GetComponent<Animator>();
        animator2 = Eco.GetComponent<Animator>();
        objetoReproductor2 = gameObject;
        
    }

    void Update()
    {
        if(Eco)
        {

        Alert = Physics.CheckSphere(transform.position, rango, playermask);
        if(Alert)
        {
            Attack2 = true;
            animator.SetBool("Alert",true);

            if (!alert2)
            {
                AudioSource audioSource1 = objetoReproductor2.GetComponent<AudioSource>();
                if (audioSource1 == null)
                {
                    audioSource1 = objetoReproductor2.AddComponent<AudioSource>();
                }
                audioSource1.clip = audioClip1;
                audioSource1.Play();
                alert2 = true;
            }
            
        }
        else
        {
            Attack2 = false;
            animator.SetBool("Alert",false);
            alert2 = false;
        }
        if(Alert == true && !attack)
        {
            Vector3 posPlayer = new Vector3(player.position.x , transform.position.y , player.position.z);
            transform.LookAt(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, enemy.speed * Time.deltaTime );
        }

         attack = Physics.CheckSphere(new Vector3(transform.position.x,transform.position.y+1,transform.position.z), 1.1f, playermask);
        if(attack == true && enemy.speed != 0 && enemy.heal>0)
        {
            if (Time.time > nextTime)
            {
                animator.SetTrigger("Attack");

                AudioSource audioSource2 = objetoReproductor2.GetComponent<AudioSource>();
                if (audioSource2 == null)
                {
                    audioSource2 = objetoReproductor2.AddComponent<AudioSource>();
                }
                audioSource2.clip = audioClip2;
                audioSource2.Play();     

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
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y,transform.position.z) , rango);

         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y+1,transform.position.z), 1.1f);
    } 

     IEnumerator Knockback()
    {
        if(Eco)
        {
            heal=enemy.heal/20;
            float startTime=Time.time;
            //animator.SetBool("Knockback",true);
            animator2.SetTrigger("KnockBack");
            while(Time.time < startTime+ KnockbackTime )
            {
            playerController.player.Move((player.transform.position-new Vector3(transform.position.x,player.transform.position.y-1,transform.position.z))*KnockbackForce*heal*Time.deltaTime);
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
        if(enemy.heal > 0)
        {
            stars.SetActive(true);
            yield return new WaitForSeconds(2);
            stars.SetActive(false);
            enemy.speed=speed1;
        }
     }

     
}
