using UnityEngine;
using UnityEngine.Audio;

public class MenuAjustes : MonoBehaviour
{
    public AudioMixer mainMixer;
    public AudioMixer Voces;
    public AudioMixer Otros;
    public AudioMixer Pasos;


    public void SetPantallaCompleta(bool PantallaEstaCompleta)
    {
        Screen.fullScreen = PantallaEstaCompleta;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolume(float volume)
    {
     mainMixer.SetFloat("volume", volume);
     Voces.SetFloat("volume", volume+10);
     Otros.SetFloat("volume", volume);
     Pasos.SetFloat("volume", volume+10);
    }
}
