using UnityEngine;

public class SingleAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float delay = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Reproducir el audio después del retraso especificado
        Invoke("PlayAudio", delay);
    }

    private void PlayAudio()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
