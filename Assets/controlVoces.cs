/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class controlVoces : MonoBehaviour
{
    public AudioMixer Voces;
    public GameObject poder;
    void Start()
    {
        Voces.SetFloat("volume", -80f);
    }

    void Update()
    {   
        if(poder == null)
        {
            vocesControl.SetActive(true);
        }
        if(result)
        {
            Voces.SetFloat("volume",volumen+20);
        }
        else
        {
            Voces.SetFloat("volume", -80f);
        }
    }
    // Update is called once per frame
    /*private void OnTriggerEnter(Collider other) {
        
      if(other.gameObject.CompareTag("Player"))
      {
          result =  MainMixer.GetFloat("volume", out volumen);
          if(result){
              Destroy(gameObject, 5f);
           }else{
             
           }
      }
  }#1#
}
*/
