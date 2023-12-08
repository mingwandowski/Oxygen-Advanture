using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorgiSniffWalkState : CorgiSniffState
{
    public CorgiSniffWalkState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
    {
    }

    public override void EnterState() {
        base.EnterState();
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void Update() {
        // base.Update();
        if (!corgi.isSniffing) {
            ToggleShowBonesOrder(false);
            stateMachine.ChangeState(corgi.idleState);
        } else if (!corgi.IsMoving()) {
            stateMachine.ChangeState(corgi.sniffState);
        }
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
        corgi.SetVelocity(corgi.walkSpeed * corgi.inputDirection.x);
    }
}
