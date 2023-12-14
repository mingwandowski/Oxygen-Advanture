using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContextSystem : MonoBehaviour
{
    public GameObject contextObject;
    public TextMeshProUGUI contextText;
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
        inputControl.Gameplay.Enable();
        contextObject.SetActive(false);
        onCompleted?.Invoke();
    }
}
