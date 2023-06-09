using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnminion1 : MonoBehaviour
{
    public Transform spawn;
    public GameObject minion;
    public bool c=false;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!c)
            {
                Instantiate(minion,spawn.transform.position,spawn.transform.rotation);
                c=true;
            }
        }
    }
}
