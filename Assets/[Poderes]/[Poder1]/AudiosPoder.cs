using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudiosPoder : MonoBehaviour
{
    
    public AudioMixer Otros;
    public AudioMixer MainMixer;
    public float volumen;
  //  public GameObject vocesControl;
    public GameObject poder;
    public BoxCollider box;
    public bool result = false;
    // Start is called before the first frame update
    public AudioMixer Voces;
    void Start()
    {
        Voces.SetFloat("volume", -80f);
        Voces.GetFloat("volume", out volumen);
        Debug.Log(volumen);
    }

    void Update()
    {   
        if(poder == null)
        {
            box.enabled = true;
        }
        if(result)
        {
            Voces.SetFloat("volume",volumen+10);
        }
        else
        {
            Voces.SetFloat("volume", -80f);
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        
      if(other.gameObject.CompareTag("Player"))
      {
          result =  MainMixer.GetFloat("volume", out volumen);
          if(result){
              Destroy(gameObject, 5f);
           }else{
             
           }
      }
  }
}
