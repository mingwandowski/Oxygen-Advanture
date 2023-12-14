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
            new Dialogue[] {
            new Dialogue(0, "Oxygen~"), 
            new Dialogue(0, "Guajiguaji~ come home for dinner~~~"), 
            new Dialogue(0, "Come on~")
        });
        dialogues.Add(
            "squirrel_1", 
            new Dialogue[] {
            new Dialogue(1, "Haha~"), 
            new Dialogue(1, "You'll never catch me!"), 
            new Dialogue(1, "I have the toilet paper that you need."),
            new Dialogue(1, "Do you want it?"),
            new Dialogue(1, "You'll need to find a pinecone for me first."),
            new Dialogue(1, "There should be some on the right side, where the monsters are."),
            new Dialogue(1, "They are hard to see but you can smell it.")
        });
        dialogues.Add(
            "squirrel_2", 
            new Dialogue[] {
            new Dialogue(1, "Wow, I know you can do this!"), 
            new Dialogue(1, "Come back to me and promise me you won't chase me again"), 
            new Dialogue(1, "Then I'll give you toilet paper.")
        });
        dialogues.Add(
            "squirrel_3", 
            new Dialogue[] {
            new Dialogue(1, "Nice job!"), 
            new Dialogue(1, "Here is your toilet paper."), 
            new Dialogue(1, "Go save your mom."),
            new Dialogue(1, "But, remember!"),
            new Dialogue(1, "You will never catch me~~~~~~~~")
        });

        dialogues.Add(
            "dan_need_toilet_paper", 
            new Dialogue[] {
            new Dialogue(0, "Oxygen!"), 
            new Dialogue(0, "Hurry!"), 
            new Dialogue(0, "I can't feel my legs!")
        });

        dialogues.Add(
            "scene2_start", 
            new Dialogue[] {
            new Dialogue(0, "Sorry Oxygen,"), 
            new Dialogue(0, "I need to go the the bathroom first."), 
            new Dialogue(0, "Oh!!!"),
            new Dialogue(0, "We have run out of toilet paper!"),
            new Dialogue(0, "You need to help me find some, Oxygen!"),
            new Dialogue(0, "Hurry!!!!")
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
        inputControl.Gameplay.Disable();
        dialogueObject.SetActive(true);
        PlayDialogue(currentDialogueIdx);
    }

    private void PlayDialogue(int idx) {
        if (currentDialogue.Length <= idx) {
            dialogueObject.SetActive(false);
            showDialogue = false;
            inputControl.Gameplay.Enable();
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
