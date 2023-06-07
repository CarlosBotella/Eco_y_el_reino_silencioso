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

    void Start()
    {
        imagen = GameObject.Find("ECO/Canvas/Poder1");
        if (objetoParaActivar != null)
        {
            objetoParaActivar.SetActive(true);
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
        // ...
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
