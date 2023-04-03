using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    public float heal = 50f;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Attibute>().Cuarar(heal);
            Destroy(gameObject);
        }
        print(other.tag);
    }
}
