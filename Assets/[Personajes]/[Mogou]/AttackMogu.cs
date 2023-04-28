using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMogu : MonoBehaviour
{

    public float life = 3f;
    private PlayerController Eco;
    private Attibute attibute;
    public float attack = 18;
   void Awake() {
        Destroy(gameObject,life);
    }

    void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject.tag =="Player")
        {   
            Eco = collision.transform.gameObject.GetComponent<PlayerController>();
            attibute = collision.transform.gameObject.GetComponent<Attibute>();
            attibute.TakeDamage(attack);
            Eco.playerSpeed = 7.5f;
            
        }
         Destroy(gameObject);
    }
}
