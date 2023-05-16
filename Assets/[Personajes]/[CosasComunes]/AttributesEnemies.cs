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
    private GameObject mainCamera;

    void Start()
    {
         Eco = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");
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
            player1.attack = 10;
            playerController.playerSpeed = 10;
              if(IsBoss)
            {
                boss.SetActive(false);
            }
            Destroy(gameObject,0.1f);
        }
    }
    
   private void showtextdmg(float dmg)
    {   
        var go=Instantiate(textdmg,transform.position,Quaternion.LookRotation(mainCamera.transform.rotation * Vector3.forward , mainCamera.transform.rotation * Vector3.up),transform);
        go.GetComponent<TextMesh>().text = dmg.ToString();
    }
    
}
