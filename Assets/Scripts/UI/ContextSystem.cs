using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContextSystem : MonoBehaviour
{
    public GameObject contextObject;
    public TextMeshProUGUI contextText;
    public Image image;
    public bool showContextImage = false;
    private InputControl inputControl;
    private Dictionary<string, string[]> dictionary = new();
    private string[] currentContext;

    private void Awake() {
        inputControl = GameManager.instance.inputControl;
        contextObject.SetActive(false);
    }

    private void Start() {
        dictionary.Add("scene1_start", new string[] {
            "Long long ago", 
            "There is a cute dog named Oxygen",
            "Oxygen is a good dog",
            "She enjoys her life with her owner every day"
        });

        dictionary.Add("scene2_start", new string[] {
            "It's 4:30 pm now.", 
            "Time to go out for a walk~~",
            "But!"
        });

        dictionary.Add("scene3_start", new string[] {
            "This night", 
            "Oxygen has an amazing dream",
            "She dreams that there's an old dog telling her",
            "that there is a treasure under the tree..."
        });
    }

    private void Update() {
        
    }

    public void ShowContext(string name, Action onCompleted = null) {
        currentContext = dictionary[name];
        contextObject.SetActive(true);
        inputControl.Gameplay.Disable();
        StartCoroutine(PlayContextCoroutine(onCompleted));
    }

    private IEnumerator PlayContextCoroutine(Action onCompleted) {
        foreach (string str in currentContext) {
            contextText.text = str;
            yield return new WaitForSeconds(2);
        }
        if (showContextImage) {
            StartCoroutine(PlayImage(onCompleted));
        } else {
            inputControl.Gameplay.Enable();
            contextObject.SetActive(false);
            onCompleted?.Invoke();
        }
    }

    private IEnumerator PlayImage(Action onCompleted) {
        // show image
        Color color = image.color;
        color.a = 1;
        image.color = color;

        yield return new WaitForSeconds(2);

        float fadeDuration = 2f;

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
        inputControl.Gameplay.Enable();
        contextObject.SetActive(false);
        onCompleted?.Invoke();
    }
}
