using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogoTrigger : MonoBehaviour
{
    public Camera cam;
    public GameObject panel;
    public Text textoDialogo;
    public string nombrePersonaje;
    public bool OnStart;
    public string[] lineas;
    public float velocidadTexto = 0.1f;
    private int index;
    private bool dentroDeRango;
    public bool acabado;
    public string tagEco;
    private string text;
    public AudioSource audioSource; 

    private bool isPlayingAudio; 

    void Start()
    {
        textoDialogo.text = string.Empty;
        Time.timeScale = 0f;
        for (int i = 0; i < lineas.Length; i++)
        {
            if (nombrePersonaje != "Narrador")
            {
                textoDialogo.fontStyle = FontStyle.Normal;
                string temp = lineas[i];
                lineas[i] = "<b>" + nombrePersonaje + ": </b>" + temp;
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
            StartDialogue();
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (dentroDeRango || OnStart))
        {
            if (textoDialogo.text == lineas[index])
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
        if (collision.gameObject.CompareTag(tagEco) && !OnStart)
        {
            panel.SetActive(true);
            dentroDeRango = true;
            textoDialogo.text = string.Empty;
            StartDialogue();
        }

    }

    public void StartDialogue()
    {
        cam.GetComponent<CinemachineBrain>().enabled = false;
        Time.timeScale = 0f;
        index = 0;
        StartCoroutine(WriteLine());
        acabado = true;

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
            for (int i = nombrePersonaje.Length + 9; i < lineas[index].ToCharArray().Length; i++)
            {
                textoDialogo.text += lineas[index].ToCharArray()[i];
                yield return new WaitForSecondsRealtime(velocidadTexto);
            }
        }
        else
        {
            foreach (char letra in lineas[index].ToCharArray())
            {
                textoDialogo.text += letra;
                yield return new WaitForSecondsRealtime(velocidadTexto);
            }
        }
    }

    public void NextLine()
    {
        textoDialogo.text = string.Empty;
        if (index < lineas.Length - 1)
        {
            index++;
            StartCoroutine(WriteLine());
        }
        else
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            cam.GetComponent<CinemachineBrain>().enabled = true;

            // Detiene la reproducción del sonido en bucle
            if (isPlayingAudio && audioSource != null)
            {
                audioSource.Stop();
                isPlayingAudio = false;
            }
        }
    }

}
