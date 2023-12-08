using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] private string message;
    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (isTriggered) return;
        if (other.CompareTag("Player")) {
            UIManager.instance.Notify(message);
            isTriggered = true;
        }
    }
}
