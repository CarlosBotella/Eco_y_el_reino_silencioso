using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTrigger : MonoBehaviour
{
    private bool dentroDeRango;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dentroDeRango = true;
            Debug.Log("iniciar dialogo");
        }
        
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dentroDeRango = false;
            Debug.Log("no se puede iniciar dialogo");
        }
        
    }
}
