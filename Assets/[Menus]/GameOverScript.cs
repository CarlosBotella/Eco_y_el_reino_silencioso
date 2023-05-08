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
<<<<<<< Updated upstream:Assets/[Menus]/GameOverScript.cs
        Cursor.visible = true;
=======
>>>>>>> Stashed changes:Assets/[Personajes]/[ECO]/GameOverScript.cs
        Cursor.lockState = CursorLockMode.None;
    }

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continuar()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        print(scene.name);
    }
}
