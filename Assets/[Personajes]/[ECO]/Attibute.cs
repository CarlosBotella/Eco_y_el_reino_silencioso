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


    private void Update()
    {
        vida.fillAmount=heal/100;
    }

    public void TakeDamage(float amount){


        heal-= amount;

         if(heal<=0)
        {
            vida.fillAmount=0;
            Destroy(gameObject);
            GameOverScript.Setup();
        }
    }
}
