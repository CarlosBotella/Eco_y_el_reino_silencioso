using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAtack : MonoBehaviour
{
    public float rango = 3;
    Attributeenemy1 attributeenemy1;
    Attributeenemy1 attributeboss1;

    Attributeenemy2 attributeenemy2;

    AttributeMiniSwampit attributeMiniSwampit;
    AttributeMogou attributeMogou;
    AttributeStormbitz attributeStormbitz;
    public Attibute player;
    private float nextTime=0;
    public float AttackCooldown = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame(
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction*rango));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction*rango));
        if(Physics.Raycast(theRay, out RaycastHit hit, rango))
        {
            //Dark Nibble
            if(hit.collider.CompareTag("Enemigo1"))
            {
                if(Time.time > nextTime)
                {       
                    if(Input.GetMouseButtonDown(0))
                    {
                        attributeenemy1 = hit.collider.gameObject.GetComponent<Attributeenemy1>();
                        attributeenemy1.TakeDamage(player.attack);
                        nextTime = Time.time+AttackCooldown;
                    }
                }
            }

            // Dark nibble king
            if(hit.collider.CompareTag("Boss1"))
            {
                if(Time.time > nextTime)
                {       
                    if(Input.GetMouseButtonDown(0))
                    {
                        attributeboss1 = hit.collider.gameObject.GetComponent<Attributeenemy1>();
                        attributeboss1.TakeDamage(player.attack);
                        nextTime = Time.time+AttackCooldown;
                    }
                }
            }

            //Swampit
             if(hit.collider.CompareTag("Swampit"))
            {
                if(Time.time > nextTime)
                {       
                    if(Input.GetMouseButtonDown(0))
                    {
                        attributeenemy2 = hit.collider.gameObject.GetComponent<Attributeenemy2>();
                        attributeenemy2.TakeDamage(player.attack);
                        nextTime = Time.time+AttackCooldown;
                    }
                }
            }

            //MiniSwampit
             if(hit.collider.CompareTag("MiniSwampit"))
            {
                if(Time.time > nextTime)
                {       
                    if(Input.GetMouseButtonDown(0))
                    {
                        attributeMiniSwampit = hit.collider.gameObject.GetComponent<AttributeMiniSwampit>();
                        attributeMiniSwampit.TakeDamage(player.attack);
                        nextTime = Time.time+AttackCooldown;
                    }
                }
            }

            //Mogou
             if(hit.collider.CompareTag("Mogou"))
            {
                if(Time.time > nextTime)
                {       
                    if(Input.GetMouseButtonDown(0))
                    {
                        attributeMogou = hit.collider.gameObject.GetComponent<AttributeMogou>();
                        attributeMogou.TakeDamage(player.attack);
                        nextTime = Time.time+AttackCooldown;
                    }
                }
            }

            //Stormbitz
             if(hit.collider.CompareTag("Stormbitz"))
            {
                if(Time.time > nextTime)
                {       
                    if(Input.GetMouseButtonDown(0))
                    {
                        attributeStormbitz = hit.collider.gameObject.GetComponent<AttributeStormbitz>();
                        attributeStormbitz.TakeDamage(player.attack);
                        nextTime = Time.time+AttackCooldown;
                    }
                }
            }


            
        }
    }
}
