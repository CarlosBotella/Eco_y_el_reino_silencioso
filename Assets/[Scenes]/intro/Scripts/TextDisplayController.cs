using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayController : MonoBehaviour
{
    [SerializeField] private Text[] textObjects;
    [SerializeField] private float[] durations;

    private int currentIndex = 0;
    private float timer = 0f;
    private bool isLastText = false;
    private bool isSequenceComplete = false;
    private string[] originalTexts;

    private void Start()
    {
        originalTexts = new string[textObjects.Length];
        for (int i = 0; i < textObjects.Length; i++)
        {
            originalTexts[i] = textObjects[i].text;
        }
        ShowText(currentIndex);
    }

    private void Update()
    {
        if (isSequenceComplete)
        {
            return;
        }
        if (timer >= durations[currentIndex])
        {
            timer = 0f;
            NextText();
        }
        timer += Time.deltaTime;
    }

    private void ShowText(int index)
    {
        isLastText = false;
        for (int i = 0; i < textObjects.Length; i++)
        {
            if (i == index)
            {
                StartCoroutine(AnimateTextAppearance(textObjects[i], originalTexts[i]));
            }
            else
            {
                textObjects[i].gameObject.SetActive(false);
                textObjects[i].text = originalTexts[i];
            }
        }
        timer = 0f;
    }

    private void NextText()
    {
        currentIndex++;
        if (currentIndex >= textObjects.Length)
        {
            currentIndex = textObjects.Length - 1;
            isLastText = true;
        }
        ShowText(currentIndex);
    }

    private IEnumerator AnimateTextAppearance(Text text, string originalText)
    {
        text.gameObject.SetActive(true);
        text.text = "";
        float charDelay = 0.05f;
        int charIndex = 0;
        while (charIndex < originalText.Length)
        {
            text.text += originalText[charIndex];
            charIndex++;
            yield return new WaitForSeconds(charDelay);
        }
    }
}
