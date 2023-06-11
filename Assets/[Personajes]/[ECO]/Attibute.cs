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
    private PlayerController playerController;
    private float maxheal;
    private float timedmg;
    public MenuPausa menuPausa;
    private Animator animator;
    private bool done=false;
    public GameObject Particleheal;
    


    private void Start()
    {
        maxheal = heal;
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        vida.fillAmount = heal / 100;
        if (heal < maxheal - 30 && Time.time > timedmg + 10 && heal>0)
        {
            if (heal != maxheal - 30)
            {   
                if(!done)
                {
                    Instantiate(Particleheal,transform.position,transform.rotation);
                    done=true;
                }
                heal = heal + 5 * Time.deltaTime;
            }
        }
        else 
        {
            done = false;
        }


        if (Input.GetKeyDown(KeyCode.P) && !PanelAjustes.activeSelf && !ConfirmarSalir.activeSelf)
        {
            menuPausa.Setup();
        }
        if (heal <= 0)
        {
            vida.fillAmount = 0;
            playerController.playerSpeed=0;
            playerController.jumpForce = 0;
            playerController.jumpForce = 0;
            animator.SetTrigger("Die");
            Invoke("Die",3f);
            //Destroy(gameObject, 5f);
        }
    }

    public void TakeDamage(float amount)
    {


        heal -= amount;
        timedmg = Time.time;
        if (heal <= 0)
        {
            vida.fillAmount = 0;
            playerController.playerSpeed=0;
            playerController.jumpForce = 0;
            animator.SetTrigger("Die");
            Invoke("Die",3f);
            //Destroy(gameObject, 5f);
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

    private void Die()
    {
        GameOverScript.Setup();
    }
}