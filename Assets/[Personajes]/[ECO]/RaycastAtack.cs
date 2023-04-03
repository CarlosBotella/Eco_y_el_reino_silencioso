using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAtack : MonoBehaviour
{
    public float rango;
    Attributeenemy1 attributeenemy1;
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
        }
    }
}
