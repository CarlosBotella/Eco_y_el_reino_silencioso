using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPrueba : MonoBehaviour
{
    
    public Attibute player;
    public Attributeenemy1 enemy;
     private bool Alert;
     public float rango;
     public Transform enemyv;
     public LayerMask playermask;
      private float nextTime=0;
      public float attackCooldown=2;

    // Update is called once per frame
    void Update()
    {
        if(enemyv)
        {
        Vector3 posEnemu = new Vector3(enemyv.position.x , transform.position.y , enemyv.position.z);
        Alert = Physics.CheckSphere(transform.position, rango, playermask);
        if(Alert==true)
        {
            if(Time.time>nextTime)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    transform.LookAt(posEnemu);
                    enemy.TakeDamage(player.attack);
                    nextTime=Time.time+attackCooldown;
                }
            }
            
        }
        }
       
    }

     private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rango);
    }

    
}
