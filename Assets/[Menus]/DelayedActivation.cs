using UnityEngine;

public class DelayedActivation : MonoBehaviour
{
    [SerializeField]
    private float delay = 2f; // El tiempo de espera en segundos

    [SerializeField]
    private GameObject objectToActivate; // El objeto que queremos activar tras el delay

    private float timer;
    private bool isActivated;

    private void Start()
    {
        // Desactivamos el objeto al inicio
        objectToActivate.SetActive(false);

        // Iniciamos el temporizador
        timer = 0f;
        isActivated = false;
    }

    private void Update()
    {
        if (!isActivated)
        {
            // Incrementamos el temporizador
            timer += Time.deltaTime;

            // Verificamos si ha pasado el tiempo de delay
            if (timer >= delay)
            {
                // Activamos el objeto
                objectToActivate.SetActive(true);
                isActivated = true;
            }
        }
    }
}
