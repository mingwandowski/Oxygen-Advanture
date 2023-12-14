using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biteable : MonoBehaviour
{
    public string dialogueKey = "go_home";
    public GameObject nextTriggerPoint;

    private SpriteRenderer sr;
    public Sprite sprite;
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
            other.GetComponent<Corgi>().sthInMouth = true;
            found = true;
            sr.enabled = true;
            // sr.sortingLayerName = "Front";
            ps.Stop();
            ps.Clear();
            coll.enabled = false;
            StartCoroutine(ShowDialogue());
        }
    }

    private IEnumerator ShowDialogue() {
        yield return new WaitForSeconds(3f);
        GameManager.instance.dialogueSystem.ShowDialogue(dialogueKey);
        if (nextTriggerPoint != null)
            nextTriggerPoint.SetActive(true);
    }

    private void FollowPlayer() {
        rb.transform.position = GameManager.instance.corgi.transform.position + new Vector3(0, 1, 0);
    }

    public void ChangeSprite() {
        sr.sprite = sprite;
    }
}
