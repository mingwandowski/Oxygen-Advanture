using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (isTriggered) return;
        if (other.CompareTag("Player")) {
            GameManager.instance.contextSystem.ShowContext("start");
            isTriggered = true;
        }
    }
}
