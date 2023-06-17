using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class DialogoTrigger1 : MonoBehaviour
{
    public bool destruir;
    public Camera cam;
    public GameObject panel; // poner panel
    public Text textoDialogo;
    public string nombrePersonaje;
    public bool OnStart; 
    [SerializeField] string[] lineas2;
    public float velocidadTexto = 0.1f;
    private int index;
    private bool dentroDeRango;
    public bool acabado;
    public string tagEco; // para Eco --> "Capsula Eco"
    bool hecho=false;
    public bool poder;
    public Collider _collider;
    public AudioSource audioSource;
    private bool isPlayingAudio;

    void Start()
    {
        Time.timeScale = 0f;
        for (int i = 0; i < lineas2.Length; i++)
        {
            if (nombrePersonaje != "Narrador")
            {
                textoDialogo.fontStyle = FontStyle.Normal;
                string temp = lineas2[i];
                lineas2[i] = "<b>"+ nombrePersonaje +": </b>" + temp;
            }
            else
            {
                textoDialogo.fontStyle = FontStyle.Italic;
            }
        }

        if (OnStart)
        {
            panel.SetActive(true);
            textoDialogo.text = string.Empty;
            StartDIalogue();
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (dentroDeRango || OnStart) )
        {
            if (textoDialogo.text == lineas2[index])
            {
                NextLine();
            }
            else
            {
                velocidadTexto = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        _collider = collision;
        if(!hecho)
        {
            if (collision.gameObject.CompareTag(tagEco) && !OnStart)
            {
            panel.SetActive(true);
            dentroDeRango = true;
            textoDialogo.text = string.Empty;
            StartDIalogue();
            }
        }
        
    }

    public void StartDIalogue()
    {
        Time.timeScale = 0f;
        cam.GetComponent<CinemachineBrain>().enabled = false;
        OnStart = false;
        index = 0;
        StartCoroutine(WriteLine());
        // Inicia la reproducción del sonido en bucle
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.loop = true;
            audioSource.Play();
            isPlayingAudio = true;
        }


    }

    IEnumerator WriteLine()
    {
        if (nombrePersonaje != "Narrador")
        {
            textoDialogo.text += "<b>" + nombrePersonaje + ": </b>";

            // Este método va escribiendo letra a letra cada x tiempo
            for (int i = nombrePersonaje.Length + 9; i < lineas2[index].ToCharArray().Length; i++)
            {
                textoDialogo.text += lineas2[index].ToCharArray()[i];

                yield return new WaitForSecondsRealtime(velocidadTexto);
            }
        }
        else
        {

            foreach (char letra in lineas2[index].ToCharArray())
            {

                textoDialogo.text += letra;

                yield return new WaitForSecondsRealtime(velocidadTexto);
            }
            
        }
    }

    public void NextLine()
    {
        if (index < lineas2.Length - 1)
        {
            index++;
            textoDialogo.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            panel.SetActive(false);
            acabado = true;
            hecho = true;
            Time.timeScale = 1f;
            textoDialogo.text = string.Empty;
            if (!(_collider.Equals(null))&& poder == true)
            {
                if (gameObject.GetComponent<ConseguirPoder1>() != null)
                {
                    gameObject.GetComponent<ConseguirPoder1>().destruir = true;
                    gameObject.GetComponent<ConseguirPoder1>().prueba(_collider);
                }

                
            }
            cam.GetComponent<CinemachineBrain>().enabled = true;

            // Detiene la reproducción del sonido en bucle
            if (isPlayingAudio && audioSource != null)
            {
                audioSource.Stop();
                isPlayingAudio = false;
            }

            if (destruir)
            {
                Destroy(gameObject);
            }
        }
    }
   
}
