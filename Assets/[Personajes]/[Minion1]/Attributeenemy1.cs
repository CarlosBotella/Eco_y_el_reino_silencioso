using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributeenemy1 : MonoBehaviour
{
    public float heal;
    public float attack;
    public GameObject textdmg;
    public Transform player;
    public Attibute player1;
    private Attributeenemy1 attributeenemy1;
    private float criticChanche = 0.15f;
    private float criticDmg = 1.5f;

    void Start()
    {
        attributeenemy1 = GetComponent<Attributeenemy1>();
    }
    public void TakeDamage(float amount){
        float totalDmg = amount;
        if(Random.Range(0f,1f)<=criticChanche)
        {
            totalDmg*=criticDmg;
        }
        if(textdmg){
             showtextdmg(totalDmg);
        }
         heal-= totalDmg;
         if(heal<=0)
        {
            Destroy(gameObject);
        }
    }
    
   private void showtextdmg(float dmg)
    {   
        Vector3 relativePos = transform.position - player.position;
        var go=Instantiate(textdmg,transform.position,Quaternion.LookRotation(relativePos, Vector3.up),transform);
        go.GetComponent<TextMesh>().text = dmg.ToString();
    }


}
