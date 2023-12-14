using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    private bool isTriggered = false;
    public string contextKey = "";
    public string dialogueKey = "";
    public float dialogueShowTime = 1f;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other) {
        if (isTriggered) return;
        if (other.CompareTag("Player")) {
            isTriggered = true;
            if (contextKey != "") {
                GameManager.instance.contextSystem.ShowContext(contextKey, () => {
                    audioSource.Play();
                });
            }
            if (dialogueKey != "") {
                StartCoroutine(ShowDialogue());
            }
        }
    }

    private IEnumerator ShowDialogue() {
        yield return new WaitForSeconds(dialogueShowTime);
        GameManager.instance.dialogueSystem.ShowDialogue(dialogueKey);
    }
}
