using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void Setup()
    {
        print("MUELTO");
        gameObject.SetActive(true);
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continuar()
    {
        print("1");
        SceneManager.LoadScene("1");
    }
}
