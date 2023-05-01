using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAtack : MonoBehaviour
{
    public float rango = 3;
    AttributesEnemies attributesEnemies;
    Attibute player;
    private float nextTime=0;
    public float AttackCooldown = 1;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Attibute>();
    }

    // Update is called once per frame(
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction*rango));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction*rango));
        if(Physics.Raycast(theRay, out RaycastHit hit, rango,layerMask))
        {
            if(Time.time > nextTime)
                {       
                    if(Input.GetMouseButtonDown(0))
                    {
                        attributesEnemies = hit.collider.gameObject.GetComponent<AttributesEnemies>();
                        attributesEnemies.TakeDamage(player.attack);
                        nextTime = Time.time+AttackCooldown;
                    }
                } 
        }
    }
}
