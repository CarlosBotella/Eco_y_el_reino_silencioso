using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialogoTrigger : MonoBehaviour
{
    // Para que funcione correctamente tiene que tener 
    
    public GameObject panel;
    public Text textoDialogo;
    public Text nombrePersonaje;
    public string[] lineas;
    public float velocidadTexto = 0.1f;
    private int index;
    private bool dentroDeRango;
    public CharacterController cc;
    void Start()
    {
        nombrePersonaje.text = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && dentroDeRango)
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
        
        if (collision.gameObject.CompareTag("Capsula Eco"))
        {
            //cc = collision.gameObject.GetComponent<CharacterController>();
            cc.enabled = false;
            panel.SetActive(true);
            textoDialogo.text = string.Empty;
            dentroDeRango = true;
            Debug.Log("iniciar dialogo");
            textoDialogo.text = string.Empty;
            StartDIalogue();
        }
        
    }
    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
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
        // Este método va escribiendo letra a letra cada x tiempo
        foreach (char letra in lineas[index].ToCharArray())
        {
            textoDialogo.text += letra;

            yield return new WaitForSeconds(velocidadTexto);
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
}
