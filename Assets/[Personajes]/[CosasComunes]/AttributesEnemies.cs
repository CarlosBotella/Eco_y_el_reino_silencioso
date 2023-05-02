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
    PlayerController playerController;
    private GameObject boss;
    public bool IsBoss;

    void Start()
    {
         Eco = GameObject.FindWithTag("Player");
         player1 = Eco.GetComponent<Attibute>();
         playerController = Eco.GetComponent<PlayerController>();
        player  = Eco.transform;
            boss = GameObject.Find("ECO/Canvas/Boss");
    }
    public void TakeDamage(float amount){
        if(textdmg){
             showtextdmg(amount);
        }
         heal-= amount;
         if(heal<=0)
        {
            if(IsBoss)
            {
                boss.SetActive(false);
            }
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
