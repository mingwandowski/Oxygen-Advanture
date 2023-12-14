using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleButtonHandler : MonoBehaviour
{
    public Button startBtn;
    public Button aboutBtn;
    public GameObject panel;
    public AudioSource audioSource;

    private void Start() {
        startBtn.onClick.AddListener(StartGame);
        EventSystem.current.SetSelectedGameObject(startBtn.gameObject);
    }

    private void Update() {
        if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject == null) {
            EventSystem.current.SetSelectedGameObject(startBtn.gameObject);
        }
    }

    private void StartGame() {
        panel.GetComponent<Animator>().SetTrigger("FadeOut");
        StartCoroutine(FadeOutSound(1.5f));
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }

    private IEnumerator FadeOutSound(float duration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }
}
