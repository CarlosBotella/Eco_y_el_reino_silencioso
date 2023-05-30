using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private int numRepetitions = 1;
    [SerializeField] private float[] delays;

    private AudioSource audioSource;
    private int currentRepetition = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Reproducir el audio por primera vez
        PlayAudio();

        // Programar las repeticiones adicionales si es necesario
        if (numRepetitions > 1)
        {
            for (int i = 1; i < numRepetitions; i++)
            {
                float delay = (i < delays.Length) ? delays[i - 1] : 0f;
                Invoke("PlayAudio", delay);
            }
        }
    }

    private void PlayAudio()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
