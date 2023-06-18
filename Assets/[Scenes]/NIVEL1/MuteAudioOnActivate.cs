using UnityEngine;

public class MuteAudioOnActivate : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private float originalVolume;

    private void Awake()
    {
        // Guardar el volumen original del AudioSource
        originalVolume = audioSource.volume;
    }

    private void OnEnable()
    {
        // Establecer el volumen en 0 cuando el objeto se active
        audioSource.volume = 0f;
    }

    private void OnDisable()
    {
        // Restaurar el volumen original cuando el objeto se desactive
        audioSource.volume = originalVolume;
    }
}
