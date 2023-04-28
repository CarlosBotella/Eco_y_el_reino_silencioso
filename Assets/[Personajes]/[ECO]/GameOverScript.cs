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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        print(scene.name);
    }
}
