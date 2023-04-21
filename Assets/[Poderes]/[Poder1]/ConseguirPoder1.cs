using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConseguirPoder1 : MonoBehaviour
{
    public GameObject player;
    Poder1 poder1;
    public Image image;
    // Start is called before the first frame update
     void OnTriggerEnter(Collider other) {
    
        if(other.gameObject.tag=="Player")
        {
            poder1 = other.transform.gameObject.GetComponent<Poder1>();
            poder1.enabled = true;
            image.enabled = true;
            Destroy(gameObject);
        }
    }
}
