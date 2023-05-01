using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConseguirPoder4: MonoBehaviour
{
    Poder4 poder4;
    GameObject imagen;
    // Start is called before the first frame update
    void Start()
    {
        imagen = GameObject.Find("ECO/Canvas/Poder4");
    }
     void OnTriggerEnter(Collider other) {
    
        if(other.gameObject.tag=="Player")
        {
            poder4 = other.transform.gameObject.GetComponent<Poder4>();
            poder4.enabled = true;
            imagen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
