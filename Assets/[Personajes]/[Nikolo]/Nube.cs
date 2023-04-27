using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{
    GameObject Eco;
    public float Speed;
     private bool Alert;
     public float rango;
     public LayerMask playermask;
     private Transform player;
    // Start is called before the first frame update
    void Start()
    {
         Eco = GameObject.FindWithTag("Player");
         player  = Eco.transform;
    }

    // Update is called once per frame
    void Update()
    {
         Alert = Physics.CheckSphere(transform.position, rango, playermask);
         if(Alert == true)
        {
            Vector3 posPlayer = new Vector3(player.position.x , transform.position.y , player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, Speed * Time.deltaTime );
        }
    }

      private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , rango);
    } 
}
