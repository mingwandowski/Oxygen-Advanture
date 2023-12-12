using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiGroundState : CorgiState
{
    public CorgiGroundState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
    {
    }

    public override void EnterState() {
        base.EnterState();
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void Update() {
        Debug.Log("ground state");
        base.Update();
        if (corgi.inputControl.Gameplay.Jump.triggered) {
            stateMachine.ChangeState(corgi.jumpState);
        } else if (corgi.isSniffing) {
            stateMachine.ChangeState(corgi.sniffState);
        }
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }
}
