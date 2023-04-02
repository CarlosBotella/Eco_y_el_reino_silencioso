using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder1d : MonoBehaviour
{
   public float life = 3f;
   public AtriburosPoder1 poder1;
   private float stunCooldown=5f;
    private float speed;
     private Enemy1 enemy1;

    void Awake() {
        Destroy(gameObject,life);
    }
     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Enemigo1")
        {   
            enemy1 = collision.transform.gameObject.GetComponent<Enemy1>();
            Attributeenemy1 attributeenemy2 = collision.transform.gameObject.GetComponent<Attributeenemy1>();
            attributeenemy2.TakeDamage(poder1.attack);
            speed = enemy1.Speed; 
            enemy1.Speed=0;
            //Invoke("stun",5);
            StartCoroutine(stunCooldownCorutine(enemy1));
            //StartCoroutine(DelayedAction());
            
        }
        Destroy(gameObject);
    }
    public IEnumerator stunCooldownCorutine(Enemy1 enemy1)
    {
         yield return new WaitForSeconds(stunCooldown);
        enemy1.Speed=0;
        print("Hola");
         yield return new WaitForSeconds(stunCooldown);
         print("Adio");
        enemy1.Speed=speed;
    }
  
}
