using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalUI : MonoBehaviour
{
    public Image image1;
    public Image image2;

    private void Start() {
        StartCoroutine(PlayImage(image1, 2, () => {
            StartCoroutine(PlayImage(image2, 100, null));
        }));
    }

    private IEnumerator PlayImage(Image image, float fadeDuration, Action onCompleted) {
        // show image
        Color color = image.color;
        color.a = 1;
        image.color = color;

        yield return new WaitForSeconds(2);

        // Perform the fade out over time
        float startTime = Time.time;
        while (Time.time - startTime < fadeDuration) {
            float t = (Time.time - startTime) / fadeDuration;
            Color newColor = image.color;
            newColor.r = 1 - t;
            newColor.g = 1 - t;
            newColor.b = 1 - t;
            // newColor.a = 1 - t; // Fade alpha from 1 to 0
            image.color = newColor;
            yield return null;
        }

        // Ensure the sprite is completely transparent after the fade out
        Color finalColor = image.color;
        finalColor.a = 0;
        image.color = finalColor;

        // yield return new WaitForSeconds(2);
        onCompleted?.Invoke();
    }
}
