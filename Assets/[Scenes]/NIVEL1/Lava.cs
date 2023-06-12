using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    Attibute  attibute;
    public float c=0;
    public Transform spawn1;
    public Transform spawn2;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject objetoReproductor;
   private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "Player")
    {
         AudioSource audioSource = objetoReproductor.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = objetoReproductor.AddComponent<AudioSource>();
        }
        audioSource.clip = audioClip;
        audioSource.Play();
        
        attibute = other.gameObject.GetComponent<Attibute>();
        attibute.TakeDamage(20);
        if(c==0)
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.transform.position = spawn1.transform.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
         if(c>0)
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.transform.position = spawn2.transform.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
   }
}
