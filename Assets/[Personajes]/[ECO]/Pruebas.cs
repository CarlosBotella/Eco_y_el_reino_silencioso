using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            characterController.enabled=false;
            gameObject.transform.position = spawn1.position;
            characterController.enabled=true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterController.enabled=false;
            gameObject.transform.position = spawn2.position;
            characterController.enabled=true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            characterController.enabled=false;
            gameObject.transform.position = spawn3.position;
            characterController.enabled=true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            characterController.enabled=false;
            gameObject.transform.position = spawn4.position;
            characterController.enabled=true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            characterController.enabled=false;
            gameObject.transform.position = spawn5.position;
            characterController.enabled=true;
        }
    }
}
