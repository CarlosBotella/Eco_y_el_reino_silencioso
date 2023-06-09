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
<<<<<<< HEAD
    public GameObject objetoReproductor; // Nuevo objeto que reproducirï¿½ el sonido
=======
    public GameObject objetoReproductor; // Nuevo objeto que reproducirá el sonido
>>>>>>> MasoMenos

    void Start()
    {
        imagen = GameObject.Find("ECO/Canvas/Poder1");
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

    private void Update()
    {
        if (gameObject.GetComponent<DialogoTrigger1>().acabado)
        {
            destruir = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
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
=======
        // ...
>>>>>>> MasoMenos
    }

    public void prueba(Collider other)
    {
<<<<<<< HEAD
=======
        Debug.Log("TAG: " + other.gameObject.tag);
        Debug.Log("DESTRUIR: " + destruir);
>>>>>>> MasoMenos
        if (other.gameObject.CompareTag("Player") && destruir)
        {
            poder1 = other.transform.gameObject.GetComponent<Poder1>();
            poder1.enabled = true;
            imagen.SetActive(true);
            Destroy(gameObject);
        }
    }

}
