using UnityEngine;
using UnityEngine.UI;

public class ActivateObject : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objetoActivado;
    public float fundidoDuracion = 1f;
    public float volumenSonido = 1f;  // Nuevo campo para el volumen del sonido

    public AudioClip sonidoActivacion;
    private AudioSource audioSource;

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

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = sonidoActivacion;
        audioSource.volume = volumenSonido;  // Ajustar el volumen del AudioSource
    }

    private void Update()
    {
        bool activarObjeto = objeto1.activeSelf || objeto2.activeSelf;

        if (activarObjeto != estaActivado)
        {
            estaActivado = activarObjeto;
            tiempoInicio = Time.time;

            if (estaActivado)
            {
                audioSource.Play();
            }
        }

        float t = (Time.time - tiempoInicio) / fundidoDuracion;
        t = Mathf.Clamp01(t);

        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].gameObject == objetoActivado)
            {
                continue;
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
