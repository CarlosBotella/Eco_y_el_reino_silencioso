using UnityEngine;
using UnityEngine.Audio;

public class MenuAjustes : MonoBehaviour
{
    public AudioMixer mainMixer;

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
    }
}
