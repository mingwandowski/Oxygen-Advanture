using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiSniffState : CorgiState
{
    public CorgiSniffState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
    {
    }

    private GameObject[] bones;

    public override void EnterState() {
        base.EnterState();
        corgi.SetVelocity(0f);
        // Find all bones in the scene
        bones = GameObject.FindGameObjectsWithTag("Bone");
        ToggleShowBonesOrder(true);
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void Update() {
        base.Update();
        if (!corgi.isSniffing) {
            ToggleShowBonesOrder(false);
            stateMachine.ChangeState(corgi.idleState);
        } else if (corgi.IsMoving()) {
            stateMachine.ChangeState(corgi.sniffWalkState);
        }
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }

    protected void ToggleShowBonesOrder(bool show) {
        foreach (GameObject bone in bones) {
            bone.GetComponent<Bone>().ToggleShowOrder(show);
        }
    }
}
