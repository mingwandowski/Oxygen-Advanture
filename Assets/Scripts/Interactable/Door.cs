using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool isTriggered = false;
    private bool isInFrontDoor = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !isTriggered) {
            UIManager.instance.Notify("Press Enter to go inside the door");
            isTriggered = true;
        }

        if (other.CompareTag("Player")) {
            isInFrontDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isInFrontDoor = false;
        }
    }

    private void Update() {
        if (isInFrontDoor && GameManager.instance.inputControl.UI.Submit.triggered) {
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene() {
        GameManager.instance.corgi.StateMachine.CurrentState.ExitState();
        GameManager.instance.corgi.anim.SetTrigger("sit");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Scene2");
    }
}
