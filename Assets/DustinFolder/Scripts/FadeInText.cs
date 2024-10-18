using UnityEngine;
using TMPro;
using System.Collections;

public class FadeInText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textsToFade; 
    [SerializeField] private float fadeDuration = 3f; // Duration of the fade-in effect
    [SerializeField] private float delayBetweenTexts = 1f; // Delay between each text fading in
    [SerializeField] private float timeToMainMenu = 2f; // Time to wait before returning to the main menu

    private void Start()
    {
        foreach (var text in textsToFade)
        {
            if (text != null)
            {
                Color startColor = text.color;
                text.color = new Color(startColor.r, startColor.g, startColor.b, 0f); // Set initial color to transparent
            }
        }
        StartCoroutine(FadeInTextsRoutine());
    }

    private IEnumerator FadeInTextsRoutine()
    {
        foreach (var text in textsToFade)
        {
            if (text != null)
            {
                Color startColor = text.color;
                Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Target color with full visibility
                float elapsedTime = 0f;

                while (elapsedTime < fadeDuration)
                {
                    elapsedTime += Time.deltaTime;
                    text.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
                    yield return null;
                }

                text.color = endColor; // Ensures text is fully visible at the end of the fade-in
                yield return new WaitForSeconds(delayBetweenTexts); // Wait before fading in the next text
            }
        }

        yield return new WaitForSeconds(timeToMainMenu); // Wait for the specified time before booting to the main menu

        // Load the main menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
