using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasos : MonoBehaviour
{
    public GameObject leftFoot; //Drag your player's RIG/MESH/BIP/BONE for the left foot here, in the inspector.
    public GameObject rightFoot; //Drag your player's RIG/MESH/BIP/BONE for the right foot here, in the inspector.
    public List<AudioClip> SonidosAndar;
    public AudioSource audiosource;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (var item in SonidosAndar)
        {
            Debug.Log(item.name);
        }*/
    }

    public void FootstepLeft() {
        RaycastHit hit;
        Ray ray = new Ray(rightFoot.transform.position, Vector3.down * 0.05f);
        Debug.DrawRay(rightFoot.transform.position, Vector3.down * 0.5f, Color.green);
        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.GetComponent<MeshRenderer>())
        {
            
            if (hit.transform.gameObject.GetComponent<MeshRenderer>().material.name.Contains("CESPED"))
            {
                audiosource.PlayOneShot(SonidosAndar[0]);
            }
            else
            {
                if (hit.transform.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Madera") || hit.transform.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Roca") )
                {
                    audiosource.PlayOneShot(SonidosAndar[2]);
                }
            }
        }
    }
    
    public void FootstepRight() {
        RaycastHit hit;
        Ray ray = new Ray(leftFoot.transform.position, Vector3.down * 0.05f);
        Debug.DrawRay(leftFoot.transform.position, Vector3.down * 0.5f, Color.green);
        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.GetComponent<MeshRenderer>())
        {
            
            if (hit.transform.gameObject.GetComponent<MeshRenderer>().material.name.Contains("CESPED"))
            {
                audiosource.PlayOneShot(SonidosAndar[1]);
            }
            else
            {
                if (hit.transform.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Madera") || hit.transform.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Roca") )
                {
                    audiosource.PlayOneShot(SonidosAndar[3]);
                }
            }
        }
    }
}
