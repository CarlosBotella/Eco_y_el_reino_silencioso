using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingObject : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Intervalo de parpadeo en segundos
    public float minOpacity = 0.2f; // Opacidad mínima
    public float maxOpacity = 1f; // Opacidad máxima

    private Image objectImage;
    private bool isBlinking = false;

    private void Start()
    {
        objectImage = GetComponent<Image>();

        // Iniciar el parpadeo
        StartBlinking();
    }

    private void StartBlinking()
    {
        if (!isBlinking)
        {
            isBlinking = true;
            StartCoroutine(Blink());
        }
    }

    private void StopBlinking()
    {
        if (isBlinking)
        {
            isBlinking = false;
            StopCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        while (isBlinking)
        {
            float targetOpacity = objectImage.color.a == maxOpacity ? minOpacity : maxOpacity;

            // Cambiar la opacidad gradualmente
            float currentOpacity = objectImage.color.a;
            float t = 0f;
            while (t < blinkInterval)
            {
                t += Time.deltaTime;
                float newOpacity = Mathf.Lerp(currentOpacity, targetOpacity, t / blinkInterval);

                Color color = objectImage.color;
                color.a = newOpacity;
                objectImage.color = color;

                yield return null;
            }

            // Esperar el intervalo de parpadeo
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void OnDestroy()
    {
        StopBlinking();
    }
}
