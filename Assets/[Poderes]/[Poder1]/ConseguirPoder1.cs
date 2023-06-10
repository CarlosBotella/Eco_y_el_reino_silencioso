using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConseguirPoder1 : MonoBehaviour
{
    [SerializeField]
    private GameObject objetoParaActivar;

    private Poder1 poder1;
    private GameObject imagen;
    public bool destruir;

    public AudioClip audioClip; // Nueva variable para el AudioClip
    public GameObject objetoReproductor; // Nuevo objeto que reproducir� el sonido

    void Start()
    {
        imagen = GameObject.Find("ECO/Canvas/Poder1");
    }

    private void Update()
    {
        if (gameObject.GetComponent<DialogoTrigger1>().acabado)
        {
            destruir = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (objetoParaActivar != null)
            {
                objetoParaActivar.SetActive(true);
            }
            if (audioClip != null && objetoReproductor != null)
            {
                AudioSource audioSource = objetoReproductor.GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = objetoReproductor.AddComponent<AudioSource>();
                }
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }

    public void prueba(Collider other)
    {
        Debug.Log("TAG: " + other.gameObject.tag);
        Debug.Log("DESTRUIR: " + destruir);
        if (other.gameObject.CompareTag("Player") && destruir)
        {
            poder1 = other.transform.gameObject.GetComponent<Poder1>();
            poder1.enabled = true;
            imagen.SetActive(true);
            Destroy(gameObject);
        }
    }

}
