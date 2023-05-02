using UnityEngine.SceneManagement;
using UnityEngine;

public class AtajoPruebas : MonoBehaviour
{
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("PurebaTodo");
            Time.timeScale  =1f;
        }
        
    }
}
