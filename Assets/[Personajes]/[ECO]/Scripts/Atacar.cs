using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour
{
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hola");
        if(other.gameObject.layer == layerMask)
        {
            Debug.Log(other.name);
        }
    }
}
