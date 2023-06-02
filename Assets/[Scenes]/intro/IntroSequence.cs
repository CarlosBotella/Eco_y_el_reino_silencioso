using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequence : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] introImages;
    [SerializeField] private float[] imageDurations;
    [SerializeField] private float blackScreenDuration = 3.5f;
    [SerializeField] private string nextScene;

    private Image panelNegro;

    private void Awake()
    {
        panelNegro = GameObject.Find("PanelNegro").GetComponent<Image>();
        panelNegro.enabled = true;
    }

    private void Start()
    {
        StartCoroutine(PlayIntroSequence());
    }

    private System.Collections.IEnumerator PlayIntroSequence()
    {
        for (int i = 0; i < introImages.Length; i++)
        {
            FadeOutPanel();

            yield return new WaitForSeconds(1f);

            image.sprite = introImages[i];
            FadeInPanel();

            float duration = imageDurations[i];
            float timer = 0f;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            if (i != introImages.Length - 1)
            {
                FadeOutPanel();

                yield return new WaitForSeconds(1f);
            }
        }

        yield return new WaitForSeconds(blackScreenDuration);

        // Cargar la siguiente escena por nombre
        SceneManager.LoadScene("Nivel1");
    }

    private void FadeInPanel()
    {
        panelNegro.color = Color.black;
        panelNegro.CrossFadeAlpha(0f, 1f, false);
    }

    private void FadeOutPanel()
    {
        panelNegro.CrossFadeAlpha(1f, 1f, false);
    }
}
