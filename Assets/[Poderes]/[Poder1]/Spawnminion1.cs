using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnminion1 : MonoBehaviour
{
    public Transform spawnMinion;
    public GameObject minion;
    public GameObject molio;
    public bool c=false;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!c)
            {
                molio.SetActive(true);
                Instantiate(minion,spawnMinion.transform.position,spawnMinion.transform.rotation);
                c=true;
            }
        }
    }
}
