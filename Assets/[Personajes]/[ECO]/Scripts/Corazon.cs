using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    public float heal = 50f;
    private   void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player")
        {
            other.transform.GetComponent<Attibute>().Curar(heal);
            Destroy(gameObject);
        }
    }
}
