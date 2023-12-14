using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelTriggerPoint : MonoBehaviour
{
    private Collider2D coll;
    private bool triggered;
    [SerializeField] private Squirrel squirrel;
    [SerializeField] private GameObject door;

    private void Awake() {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (triggered) return;
        if (other.CompareTag("Player")) {
            if (!other.GetComponent<Corgi>().sthInMouth) {
                // first trigger
                coll.enabled = false;
                triggered = true;
                squirrel.TriggerRunAway();
            } else {
                // second trigger
                GameManager.instance.dialogueSystem.ShowDialogue("squirrel_3");
                GameObject.FindGameObjectsWithTag("Biteable")[0].GetComponent<Biteable>().ChangeSprite();
                door.GetComponent<Collider2D>().enabled = true;
            }
        }
    }
}
