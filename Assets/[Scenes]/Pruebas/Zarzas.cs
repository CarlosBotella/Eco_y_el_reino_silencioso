using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zarzas : MonoBehaviour
{
    Attibute  attibute;
    public Transform spawn;
    private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Player")
    {
        attibute = other.gameObject.GetComponent<Attibute>();
        attibute.TakeDamage(20);
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.transform.position = spawn.transform.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
}
