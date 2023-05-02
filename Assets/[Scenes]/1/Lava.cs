using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    Attibute  attibute;
   private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Player")
    {
        attibute = other.gameObject.GetComponent<Attibute>();
        attibute.TakeDamage(500);
    }
   }
}
