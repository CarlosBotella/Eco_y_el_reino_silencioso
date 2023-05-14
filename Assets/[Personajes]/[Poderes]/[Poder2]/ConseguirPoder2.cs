using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConseguirPoder2 : MonoBehaviour
{
    Poder1 poder2;
    GameObject imagen;
    // Start is called before the first frame update
    void Start()
    {
        imagen = GameObject.Find("ECO/Canvas/Poder2");
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            poder2 = other.transform.gameObject.GetComponent<Poder1>();
            poder2.enabled = true;
            imagen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
