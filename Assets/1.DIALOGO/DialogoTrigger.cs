using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogoTrigger : MonoBehaviour
{


    public GameObject panel; // poner panel
    public Text textoDialogo;
    public string nombrePersonaje;
    public bool OnStart;
    public string[] lineas;
    public float velocidadTexto = 0.1f;
    private int index;
    private bool dentroDeRango;
    public string tag; // para Eco --> "Capsula Eco"
    public CharacterController cc; // poner CharacterController de Eco
    
    void Start()
    {
        for (int i = 0; i < lineas.Length; i++)
        {
            if (nombrePersonaje != "Narrador")
            {
                textoDialogo.fontStyle = FontStyle.Normal;
                string temp = lineas[i];
                lineas[i] = "<b>"+ nombrePersonaje +": </b>" + temp;
            }
            else
            {
                textoDialogo.fontStyle = FontStyle.Italic;
            }
        }

        if (OnStart)
        {
            cc.enabled = false;
            panel.SetActive(true);
            textoDialogo.text = string.Empty;
            dentroDeRango = true;
            textoDialogo.text = string.Empty;
            StartDIalogue();
        }
    }

    
    void Update()
    {
        if (Input.anyKeyDown && (dentroDeRango || OnStart) )
        {
            if (textoDialogo.text == lineas[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textoDialogo.text = lineas[index];
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag(tag) && !OnStart)
        {
            cc.enabled = false;
            panel.SetActive(true);
            textoDialogo.text = string.Empty;
            dentroDeRango = true;
            textoDialogo.text = string.Empty;
            StartDIalogue();
        }
        
    }
    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && !OnStart)
        {
            dentroDeRango = false;
            panel.SetActive(false);
            Debug.Log("no se puede iniciar dialogo");
        }
        
    }
    public void StartDIalogue()
    {
        index = 0;
        StartCoroutine(WriteLine());

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

                yield return new WaitForSeconds(velocidadTexto);
            }
        }
        else
        {

            foreach (char letra in lineas[index].ToCharArray())
            {

                textoDialogo.text += letra;

                yield return new WaitForSeconds(velocidadTexto);
            }
        }
    }

    public void NextLine()
    {
        if (index < lineas.Length - 1)
        {
            index++;
            textoDialogo.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            cc.enabled = true;
            panel.SetActive(false);
        }
    }
    
    // TODO: Codigo modular
}
