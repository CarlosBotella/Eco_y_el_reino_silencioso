using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyxAttack : MonoBehaviour
{
    public float life = 3f;
    private PlayerController Eco;
    private Attibute attibute;
    public float attack = 16;
    private bool hasCollided = false;
   void Awake() {
        Destroy(gameObject,life);
    }

    void OnCollisionEnter(Collision collision)
    { 
        if (hasCollided) return;
        if(collision.gameObject.tag =="Player")
        {   
            Eco = collision.transform.gameObject.GetComponent<PlayerController>();
            attibute = collision.transform.gameObject.GetComponent<Attibute>();
            attibute.TakeDamage(attack);
        }
        hasCollided = true;
        Destroy(gameObject);
    }
}
