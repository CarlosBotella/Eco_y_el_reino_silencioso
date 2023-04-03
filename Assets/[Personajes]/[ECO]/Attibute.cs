using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attibute : MonoBehaviour
{
    public float heal;
    public float attack;
    public Image vida;
    public GameOverScript GameOverScript;
    private float maxheal;
    private float timedmg;


    private void Start() {
        maxheal=heal;     
    }
    private void Update()
    {
        vida.fillAmount=heal/100;
        if(heal<maxheal-30 && Time.time>timedmg+10)
        {
            if(heal!=maxheal-30)
            {
                heal=heal+5*Time.deltaTime;
            }
        }
    }

    public void TakeDamage(float amount){


        heal-= amount;
        timedmg =Time.time;
         if(heal<=0)
        {
            vida.fillAmount=0;
            GameOverScript.Setup();
            Destroy(gameObject);
            
        }
    }
    public void Cuarar(float cantidad)
    {
        float heal2=heal=heal+cantidad;
        if((heal2)>maxheal)
        {
            heal=maxheal;
        }
        else
        {
            heal=heal2;
        }

    }
}
