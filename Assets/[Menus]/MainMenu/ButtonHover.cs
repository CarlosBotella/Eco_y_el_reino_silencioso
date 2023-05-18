using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverObject;

    private void Start()
    {
        hoverObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverObject.SetActive(true);
        Color hoverColor = hoverObject.GetComponent<Image>().color;
        hoverColor.a = 0.13f; // Cambiar la opacidad a 50% (0.5)
        hoverObject.GetComponent<Image>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverObject.SetActive(false);
        Color hoverColor = hoverObject.GetComponent<Image>().color;
        hoverColor.a = 0f; // Devolver la opacidad a 0
        hoverObject.GetComponent<Image>().color = hoverColor;
    }
}
