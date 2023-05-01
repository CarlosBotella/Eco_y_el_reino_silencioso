using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MogouBullet : MonoBehaviour
{
    public float life = 3f;
    private PlayerController Eco;
    private Attibute attibute;
    public float attack;
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
            Eco.playerSpeed = 10 * 0.75f;
        }
        hasCollided = true;
        Destroy(gameObject);
    }

}
