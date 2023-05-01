using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesEnemies : MonoBehaviour
{
    GameObject Eco;
    public float heal;
    public float attack;
    public float speed;
    public GameObject textdmg;
    private Transform player;
    private Attibute player1;
    private float criticChanche = 0.15f;
    private float criticDmg = 1.5f;
    PlayerController playerController;

    void Start()
    {
         Eco = GameObject.FindWithTag("Player");
         player1 = Eco.GetComponent<Attibute>();
         playerController = Eco.GetComponent<PlayerController>();
        player  = Eco.transform;
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
            player1.attack = 10;
            playerController.playerSpeed = 10;
            Destroy(gameObject,0.1f);
        }
    }
    
   private void showtextdmg(float dmg)
    {   
        Vector3 relativePos = transform.position - player.position;
        var go=Instantiate(textdmg,transform.position,Quaternion.LookRotation(relativePos, Vector3.up),transform);
        go.GetComponent<TextMesh>().text = dmg.ToString();
    }
}
