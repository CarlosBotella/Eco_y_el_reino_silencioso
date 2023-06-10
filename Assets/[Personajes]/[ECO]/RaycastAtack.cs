using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAtack : MonoBehaviour
{
    public float rango = 1;
    AttributesEnemies attributesEnemies;
    Attibute player;
    private float nextTime=0;
    public float AttackCooldown = 1;
    public LayerMask layerMask;
    private float criticChanche = 0.15f;
    private float criticDmg = 1.5f;
    private Animator animator;
    private PlayerController playerController;
    private float speed;
    private CharacterController characterController;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Attibute>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        speed = playerController.playerSpeed;
        characterController = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame(
    void Update()
    {
        Vector3 direction = Vector3.forward;
            Ray theRay = new Ray(new Vector3(transform.position.x,transform.position.y+1.7f,transform.position.z), transform.TransformDirection(direction*rango));
            Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+1.7f,transform.position.z), transform.TransformDirection(direction*rango));
        if(Time.time > nextTime)
        { 
            if(Input.GetMouseButtonDown(0) && characterController.isGrounded)
            {
            playerController.playerSpeed=0;
            animator.SetTrigger("Attack");
            StartCoroutine(Stop(theRay));
            nextTime = Time.time+AttackCooldown;  
            } 
        }
    }

    IEnumerator Stop(Ray ray)
    {
            if(Physics.Raycast(ray, out RaycastHit hit, rango,layerMask))
            {      
                        attributesEnemies = hit.collider.gameObject.GetComponent<AttributesEnemies>();
                        float totalDmg = player.attack;
                        if(Random.Range(0f,1f)<=criticChanche)
                        {
                            totalDmg*=criticDmg;
                        }
                        yield return new WaitForSeconds(0.3f);
                        attributesEnemies.TakeDamage(totalDmg);
            } 
        yield return new WaitForSeconds(1f);
        playerController.playerSpeed=speed;
    }
}
