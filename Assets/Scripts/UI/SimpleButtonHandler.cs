using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleButtonHandler : MonoBehaviour
{
    public Button startBtn;
    public Button aboutBtn;

    private void Start() {
        startBtn.onClick.AddListener(StartGame);
        EventSystem.current.SetSelectedGameObject(startBtn.gameObject);
    }

    private void StartGame() {
        SceneManager.LoadScene(1);
    }
}
