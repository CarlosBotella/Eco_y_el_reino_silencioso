using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogoTrigger1 : MonoBehaviour
{
    public GameObject panel; // poner panel
    public Text textoDialogo;
    public string nombrePersonaje;
    public bool OnStart; 
    [SerializeField] string[] lineas2;
    public float velocidadTexto = 0.1f;
    private int index;
    private bool dentroDeRango;
    public bool acabado;
    public string tag; // para Eco --> "Capsula Eco"
    bool c=false;
    public CharacterController cc; // poner CharacterController de Eco
    
    void Start()
    {
        
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
            cc.enabled = false;
            panel.SetActive(true);
            textoDialogo.text = string.Empty;
            StartDIalogue();
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && (dentroDeRango || OnStart) )
        {
            if (textoDialogo.text == lineas2[index])
            {
                Debug.Log("LISTA"+gameObject.name + ": " + lineas2.Length);
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
        if(!c)
        {
            if (collision.gameObject.CompareTag(tag) && !OnStart)
        {
            cc.enabled = false;
            panel.SetActive(true);
            dentroDeRango = true;
            textoDialogo.text = string.Empty;
            StartDIalogue();
        }
        }
        
    }
    /*private void OnTriggerExit(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && !OnStart)
        {
            dentroDeRango = false;
            panel.SetActive(false);
            textoDialogo.text = string.Empty;
        }
        
    }*/
    public void StartDIalogue()
    {
        OnStart = false;
        index = 0;
        foreach (var linea in lineas2)
        {
            Debug.Log(linea);
        }
        StartCoroutine(WriteLine());
        
        
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

                yield return new WaitForSeconds(velocidadTexto);
            }
        }
        else
        {

            foreach (char letra in lineas2[index].ToCharArray())
            {

                textoDialogo.text += letra;

                yield return new WaitForSeconds(velocidadTexto);
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
            c=true;
            textoDialogo.text = string.Empty;
            cc.enabled = true;
        }
    }
    
    
}
