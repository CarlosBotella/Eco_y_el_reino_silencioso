using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptDialogo : MonoBehaviour
{
    public TextMeshProUGUI textoDialogo;
    public string[] lineas;
    public float velocidadTexto = 0.1f;
    private int index;

 

void Start()
{
    textoDialogo.text = string.Empty;
        StartDIalogue();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
            gameObject.SetActive(false);
        }
    }

}
