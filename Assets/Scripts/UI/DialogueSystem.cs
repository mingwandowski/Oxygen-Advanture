using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialogueObject;
    private Dictionary<string, Dialogue[]> dialogues = new();
    private Dialogue[] currentDialogue;
    private int currentDialogueIdx;
    public Sprite[] sprites;
    private InputControl inputControl;
    private bool showDialogue;
    private bool canPlayNext = true;
    public Image avatar;
    public TextMeshProUGUI text;
    public Transform nextBtn;

    private void Awake() {
        inputControl = GameManager.instance.inputControl;
    }

    private void Start() {
        dialogues.Add(
            "go_home", 
            new Dialogue[3] {
            new Dialogue(0, "Oxygen~"), 
            new Dialogue(0, "Guajiguaji~ come home for dinner~~~"), 
            new Dialogue(0, "Come on~")
        });

        dialogueObject.SetActive(false);
    }

    private void Update() {
        if (!showDialogue) return;
        if (canPlayNext && inputControl.UI.Submit.triggered) {
            PlayDialogue(currentDialogueIdx);
        }
    }

    public void ShowDialogue(string name) {
        currentDialogue = dialogues[name];
        currentDialogueIdx = 0;
        showDialogue = true;
        dialogueObject.SetActive(true);
        PlayDialogue(0);
    }

    private void PlayDialogue(int idx) {
        if (currentDialogue.Length <= idx) {
            dialogueObject.SetActive(false);
            showDialogue = false;
            return;
        }
        Dialogue dialogue = currentDialogue[idx];
        currentDialogueIdx = idx + 1;
        StartCoroutine(DialogueCoroutine(dialogue));
    }

    private IEnumerator DialogueCoroutine(Dialogue dialogue) {
        nextBtn.gameObject.SetActive(false);
        canPlayNext = false;
        avatar.sprite = sprites[dialogue.spriteIdx];
        text.text = dialogue.text;
        yield return new WaitForSeconds(1);
        nextBtn.gameObject.SetActive(true);
        canPlayNext = true;
    }
}
