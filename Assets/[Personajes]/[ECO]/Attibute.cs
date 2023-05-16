using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attibute : MonoBehaviour
{
    public float heal = 100;
    public float attack = 10;
    public Image vida;
    public GameOverScript GameOverScript;
    public GameObject PanelAjustes;
    public GameObject ConfirmarSalir;
    private float maxheal;
    private float timedmg;
    public MenuPausa menuPausa;


    private void Start()
    {
        maxheal = heal;
    }
    private void Update()
    {
        vida.fillAmount = heal / 100;
        if (heal < maxheal - 30 && Time.time > timedmg + 10)
        {
            if (heal != maxheal - 30)
            {
                heal = heal + 5 * Time.deltaTime;
            }
        }


        if (Input.GetKeyDown(KeyCode.P) && !PanelAjustes.activeSelf && !ConfirmarSalir.activeSelf)
        {
            menuPausa.Setup();
        }
    }

    public void TakeDamage(float amount)
    {


        heal -= amount;
        timedmg = Time.time;
        if (heal <= 0)
        {
            vida.fillAmount = 0;
            GameOverScript.Setup();
            Destroy(gameObject, 0.1f);
        }
    }
    public void Curar(float cantidad)
    {
        float heal2 = heal + cantidad;
        if ((heal2) > maxheal)
        {
            heal = maxheal;
        }
        else
        {
            heal = heal2;
        }

    }
}