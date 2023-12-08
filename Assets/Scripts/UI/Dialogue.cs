using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public int spriteIdx;
    public string text;

    public Dialogue(int spriteIdx, string text) {
        this.spriteIdx = spriteIdx;
        this.text = text;
    }
}
