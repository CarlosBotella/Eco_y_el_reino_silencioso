using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuESC : MonoBehaviour
{
    public GameObject EscMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscMenu.SetActive(!EscMenu.activeSelf);
        }

    }
}
