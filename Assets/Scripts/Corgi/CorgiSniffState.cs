using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiSniffState : CorgiState
{
    public CorgiSniffState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
    {
    }

    private GameObject[] biteables;

    public override void EnterState() {
        base.EnterState();
        corgi.SetVelocity(0f);
        // Find all biteables in the scene
        biteables = GameObject.FindGameObjectsWithTag("Biteable");
        ToggleShowBiteableOrder(true);
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void Update() {
        base.Update();
        if (!corgi.isSniffing) {
            ToggleShowBiteableOrder(false);
            stateMachine.ChangeState(corgi.idleState);
        } else if (corgi.IsMoving()) {
            stateMachine.ChangeState(corgi.sniffWalkState);
        }
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }

    protected void ToggleShowBiteableOrder(bool show) {
        foreach (GameObject biteable in biteables) {
            biteable.GetComponent<Biteable>().ToggleShowOrder(show);
        }
    }
}
