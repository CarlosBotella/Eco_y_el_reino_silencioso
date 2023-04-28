using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder1d : MonoBehaviour
{
   public float life = 3f;
   public AtriburosPoder1 poder1;
   public float stunTime;
    private float speed;
     private Enemy1 enemy1;
     private Boss1 boss1;
     private Minion2 swampit;
     private MiniSwampit miniSwampit;
     private Mogou mogou;
     private Stormbitz stormbitz;
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
            
        }
        if(collision.gameObject.tag =="Boss1")
        {   
            boss1 = collision.transform.gameObject.GetComponent<Boss1>();
            Attributeenemy1 attributeenemy2 = collision.transform.gameObject.GetComponent<Attributeenemy1>();
            attributeenemy2.TakeDamage(poder1.attack);
            speed = boss1.Speed;
            boss1.Speed=0;
            
        }

         if(collision.gameObject.tag =="Swampit")
        {   
            swampit = collision.transform.gameObject.GetComponent<Minion2>();
            Attributeenemy2 attributeswampit = collision.transform.gameObject.GetComponent<Attributeenemy2>();
            attributeswampit.TakeDamage(poder1.attack);
            speed = swampit.Speed;
            swampit.Speed=0;
            
        }

         if(collision.gameObject.tag =="MiniSwampit")
        {   
            miniSwampit = collision.transform.gameObject.GetComponent<MiniSwampit>();
            AttributeMiniSwampit attributeMiniSwampit = collision.transform.gameObject.GetComponent<AttributeMiniSwampit>();
            attributeMiniSwampit.TakeDamage(poder1.attack);
            speed = miniSwampit.Speed;
            miniSwampit.Speed=0;
            
        }

         if(collision.gameObject.tag =="Mogou")
        {   
            mogou = collision.transform.gameObject.GetComponent<Mogou>();
            AttributeMogou attributeMogou = collision.transform.gameObject.GetComponent<AttributeMogou>();
            attributeMogou.TakeDamage(poder1.attack);
            speed = mogou.Speed;
            mogou.Speed=0;
            
        }

         if(collision.gameObject.tag =="Stormbitz")
        {   
            stormbitz = collision.transform.gameObject.GetComponent<Stormbitz>();
            AttributeStormbitz attributeStormbitz = collision.transform.gameObject.GetComponent<AttributeStormbitz>();
            attributeStormbitz.TakeDamage(poder1.attack);
            speed = stormbitz.Speed;
            stormbitz.Speed=0;
            
        }
        Destroy(gameObject);
    }
}
