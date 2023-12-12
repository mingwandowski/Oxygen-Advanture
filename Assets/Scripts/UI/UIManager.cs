using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

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
    }

    private GameObject notification;
    private void OnEnable() {
        notification = GameObject.Find("Notification");
        notification.SetActive(false);
    }

    public void Notify(string message) {
        notification.GetComponentInChildren<TextMeshProUGUI>().text = message;
        notification.SetActive(true);
        StartCoroutine(HideNotification());
    }

    private IEnumerator HideNotification() {
        GameManager.instance.inputControl.Gameplay.Disable();
        yield return new WaitForSeconds(3);
        // TODO: fade out the notification
        notification.SetActive(false);
        GameManager.instance.inputControl.Gameplay.Enable();
    }
}
