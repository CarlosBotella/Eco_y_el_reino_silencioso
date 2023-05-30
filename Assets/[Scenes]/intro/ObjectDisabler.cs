using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    public float delay = 5f; // Tiempo de retraso en segundos

    private void Start()
    {
        Invoke("DisableObject", delay);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
