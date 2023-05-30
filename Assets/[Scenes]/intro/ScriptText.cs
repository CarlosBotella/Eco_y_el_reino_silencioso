using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScriptText : MonoBehaviour
{
    [SerializeField] private Text textObject;
    [SerializeField] private float delay = 1f;
    [SerializeField] private float duration = 3f;

    private string originalText;
    private float timer = 0f;

    private void Start()
    {
        originalText = textObject.text;
        textObject.gameObject.SetActive(false);
        StartCoroutine(ActivateTextWithDelay());
    }

    private IEnumerator ActivateTextWithDelay()
    {
        yield return new WaitForSeconds(delay);

        textObject.gameObject.SetActive(true);
        StartCoroutine(AnimateTextAppearance());
        StartCoroutine(DisableTextAfterDuration());
    }

    private IEnumerator AnimateTextAppearance()
    {
        textObject.text = "";

        float charDelay = 0.05f;
        int charIndex = 0;

        while (charIndex < originalText.Length)
        {
            textObject.text += originalText[charIndex];
            charIndex++;
            yield return new WaitForSeconds(charDelay);
        }
    }

    private IEnumerator DisableTextAfterDuration()
    {
        yield return new WaitForSeconds(duration);

        float fadeDuration = 0.5f;
        float fadeTimer = 0f;
        Color originalColor = textObject.color;

        while (fadeTimer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);
            textObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            fadeTimer += Time.deltaTime;
            yield return null;
        }

        textObject.gameObject.SetActive(false);
    }
}
