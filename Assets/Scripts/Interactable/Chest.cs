using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Sprite closeSprite;
    private SpriteRenderer sr;
    private Collider2D coll;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log(123);
            sr.sprite = openSprite;
            // coll.enabled = false;
        }
    }
}
