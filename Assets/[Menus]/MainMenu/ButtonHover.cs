using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverObject;
    public AudioClip hoverSound;

    private AudioSource audioSource;
    public float soundVolume = 0.5f; // Volumen deseado (0 a 1)

    private void Start()
    {
        hoverObject.SetActive(false);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = hoverSound;
        audioSource.playOnAwake = false;
        audioSource.volume = soundVolume; // Establecer el volumen deseado
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.Play();
        hoverObject.SetActive(true);
        Color hoverColor = hoverObject.GetComponent<Image>().color;
        hoverColor.a = 0.13f; // Cambiar la opacidad a 50% (0.5)
        hoverObject.GetComponent<Image>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        audioSource.Stop();
        hoverObject.SetActive(false);
        Color hoverColor = hoverObject.GetComponent<Image>().color;
        hoverColor.a = 0f; // Devolver la opacidad a 0
        hoverObject.GetComponent<Image>().color = hoverColor;
    }
}
