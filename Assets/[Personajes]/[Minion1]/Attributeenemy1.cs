using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributeenemy1 : MonoBehaviour
{
     public float heal;
    public float attack;
   public GameObject textdmg;
   public Transform player;
    public void TakeDamage(float amount){
        heal-= amount;
        if(textdmg && heal>0){
             showtextdmg();
        }
         if(heal<=0)
        {
            Destroy(gameObject);
        }
    }
    
   private void showtextdmg()
    {   
        Vector3 relativePos = transform.position - player.position;
        var go=Instantiate(textdmg,transform.position,Quaternion.LookRotation(relativePos, Vector3.up),transform);
        go.GetComponent<TextMesh>().text = heal.ToString();
    }

}
