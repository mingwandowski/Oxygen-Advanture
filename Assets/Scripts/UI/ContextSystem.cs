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
    private int currentContextIdx;
    private bool showContext = false;

    private void Awake() {
        inputControl = GameManager.instance.inputControl;
        contextObject.SetActive(false);
    }

    private void Start() {
        dictionary.Add("start", new string[] {
            "Long long ago", 
            "There is a cute dog named Oxygen",
            "Oxygen is a good dog",
            "She enjoys her life with her owner every day"
        });
    }

    private void Update() {
        
    }

    public void ShowContext(string name) {
        currentContext = dictionary[name];
        currentContextIdx = 0;
        showContext = true;
        contextObject.SetActive(true);
        inputControl.Gameplay.Disable();
        StartCoroutine(PlayContextCoroutine());
    }

    private IEnumerator PlayContextCoroutine() {
        foreach (string str in currentContext) {
            contextText.text = str;
            yield return new WaitForSeconds(2);
        }
        showContext = false;
        inputControl.Gameplay.Enable();
        contextObject.SetActive(false);
    }
}
