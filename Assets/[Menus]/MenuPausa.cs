using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

     public void SalirPausas()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           Resume();
        }
    }
}
