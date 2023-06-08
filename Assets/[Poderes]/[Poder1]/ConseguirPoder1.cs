using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConseguirPoder1 : MonoBehaviour
{
    Poder1 poder1;
    GameObject imagen;
    public bool destruir;
    // Start is called before the first frame update
    void Start()
    {
        imagen = GameObject.Find("ECO/Canvas/Poder1");
    }

   private void Update()
    {
        if (gameObject.GetComponent<DialogoTrigger1>().acabado)
        {
            destruir = true;
        }
    }

    void OnTriggerEnter(Collider other) {
    
        
    }

    public void prueba(Collider other)
    {
        Debug.Log("TAG: "+other.gameObject.tag);
        Debug.Log("DESTRUIR: "+destruir);
        if(other.gameObject.CompareTag("Player") && destruir )
        {
            poder1 = other.transform.gameObject.GetComponent<Poder1>();
            poder1.enabled = true;
            imagen.SetActive(true);
            Destroy(gameObject);
            
        }
    }

}
