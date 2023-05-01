using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConseguirPoder5 : MonoBehaviour
{
    // Start is called before the first frame update
    Poder5 poder5;
    GameObject imagen;
    // Start is called before the first frame update
    void Start()
    {
        imagen = GameObject.Find("ECO/Canvas/Poder5");
    }
     void OnTriggerEnter(Collider other) {
    
        if(other.gameObject.tag=="Player")
        {
            poder5 = other.transform.gameObject.GetComponent<Poder5>();
            poder5.enabled = true;
            imagen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
