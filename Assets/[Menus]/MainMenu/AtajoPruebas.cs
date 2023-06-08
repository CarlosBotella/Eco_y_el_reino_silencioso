using UnityEngine.SceneManagement;
using UnityEngine;

public class AtajoPruebas : MonoBehaviour
{
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Nivel1");
            Time.timeScale  =1f;
        }
        
    }
}
