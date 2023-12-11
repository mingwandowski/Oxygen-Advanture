using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    private SpriteRenderer sr;
    private ParticleSystem ps;
    private Rigidbody2D rb;
    private Collider2D coll;
    private bool found = false;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void Start() {
        sr.enabled = false;
        ps.Stop();
    }

    private void Update() {
        if (found) FollowPlayer();
    }

    public void ToggleShowOrder(bool show) {
        if (show && !found) {
            ps.Play();
        } else {
            ps.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (found) return;
        if (other.CompareTag("Player") && GameManager.instance.corgi.isSniffing) {
            found = true;
            sr.enabled = true;
            sr.sortingLayerName = "Front";
            ps.Stop();
            ps.Clear();
            coll.enabled = false;
            StartCoroutine(ShowDialogue());
        }
    }

    private IEnumerator ShowDialogue() {
        yield return new WaitForSeconds(3f);
        GameManager.instance.dialogueSystem.ShowDialogue("go_home");
    }

    private void FollowPlayer() {
        rb.transform.position = GameManager.instance.corgi.transform.position + new Vector3(0, 1, 0);
    }
}
