using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelTriggerPoint : MonoBehaviour
{
    private Collider2D coll;
    private bool triggered;
    [SerializeField] private Squirrel squirrel;

    private void Awake() {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (triggered) return;
        if (other.CompareTag("Player")) {
            coll.enabled = false;
            triggered = true;
            squirrel.TriggerRunAway();
        }
    }
}
