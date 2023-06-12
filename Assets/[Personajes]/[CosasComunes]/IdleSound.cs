using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSound : MonoBehaviour
{
    public int numberOfAudioSources; // Número de AudioSource que se utilizarán
    public AudioSource[] audioSources; // Array de AudioSource

    private int currentIndex; // Índice actual del AudioSource seleccionado
    private float timer; // Temporizador para el intervalo entre reproducciones
    private bool isPlaying; // Variable para verificar si se está reproduciendo un AudioSource

    private void Start()
    {
        currentIndex = -1;
        timer = 0f;
        isPlaying = false;
    }

    private void Update()
    {
        // Si no se está reproduciendo ningún AudioSource y ha pasado el intervalo de tiempo
        if (!isPlaying && timer >= 6f)
        {
            PlayRandomAudio();
        }

        // Incrementar el temporizador
        timer += Time.time;
    }

    private void PlayRandomAudio()
    {
        // Generar un índice aleatorio diferente al actual
        int randomIndex = currentIndex;
        while (randomIndex == currentIndex)
        {
            randomIndex = Random.Range(0, numberOfAudioSources);
        }

        // Asignar el nuevo índice y reproducir el AudioSource correspondiente
        currentIndex = randomIndex;
        audioSources[currentIndex].Play();

        // Reiniciar el temporizador y la variable de reproducción
        timer = 0f;
        isPlaying = true;
    }

    // Método para llamar desde otro script para detener todas las reproducciones
    public void StopAllAudio()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    // Método para llamar desde otro script para detener una reproducción específica por su índice
    public void StopAudioByIndex(int index)
    {
        if (index >= 0 && index < numberOfAudioSources)
        {
            audioSources[index].Stop();
        }
    }
}
