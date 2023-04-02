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


    // Update is called once per frame
    void Update()
    {
        if(enemyv)
        {
        Vector3 posEnemu = new Vector3(enemyv.position.x , transform.position.y , enemyv.position.z);
        Alert = Physics.CheckSphere(transform.position, rango, playermask);
        if(Input.GetMouseButtonDown(0) &&  Alert==true)
        {
            transform.LookAt(posEnemu);
            enemy.TakeDamage(player.attack);
        }
        }
       
    }

     private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
