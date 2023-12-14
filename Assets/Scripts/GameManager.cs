using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Corgi corgi;
    public DialogueSystem dialogueSystem;
    public ContextSystem contextSystem;
    public InputControl inputControl;

    private void Awake() {
        // Check if an instance already exists
        if (instance != null && instance != this) {
            // If an instance already exists and it's not this one, destroy this instance
            Destroy(this.gameObject);
            return;
        }
        // Set this instance as the singleton instance
        instance = this;
        // Ensure that this object persists between scenes
        DontDestroyOnLoad(this.gameObject);

        inputControl = new InputControl();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (corgi == null) {
            corgi = FindObjectOfType<Corgi>();
        }
    }
}
