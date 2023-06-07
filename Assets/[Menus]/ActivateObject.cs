using UnityEngine;
using UnityEngine.UI;

public class ActivateObject : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objetoActivado;
    public float fundidoDuracion = 1f;

    private Image[] images;
    private Color[] initialColors;
    private float tiempoInicio;
    private bool estaActivado;

    private void Start()
    {
        images = objetoActivado.GetComponentsInChildren<Image>();
        initialColors = new Color[images.Length];

        for (int i = 0; i < images.Length; i++)
        {
            initialColors[i] = images[i].color;

            // Si el objeto Image pertenece al objeto activado, no se aplica el fundido
            if (images[i].gameObject == objetoActivado)
            {
                images[i].color = initialColors[i];
            }
            else
            {
                images[i].color = new Color(initialColors[i].r, initialColors[i].g, initialColors[i].b, 0f);
            }
        }

        tiempoInicio = Time.time;
        estaActivado = false;
    }

    private void Update()
    {
        bool activarObjeto = objeto1.activeSelf || objeto2.activeSelf;

        if (activarObjeto != estaActivado)
        {
            estaActivado = activarObjeto;
            tiempoInicio = Time.time;
        }

        float t = (Time.time - tiempoInicio) / fundidoDuracion;
        t = Mathf.Clamp01(t);

        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].gameObject == objetoActivado)
            {
                continue; // Salta el objeto activado para mantenerlo sin fundido
            }

            if (estaActivado)
            {
                images[i].color = new Color(initialColors[i].r, initialColors[i].g, initialColors[i].b, t);
            }
            else
            {
                images[i].color = new Color(initialColors[i].r, initialColors[i].g, initialColors[i].b, 1f - t);
            }
        }

        objetoActivado.SetActive(estaActivado);
    }
}
