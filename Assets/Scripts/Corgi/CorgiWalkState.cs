using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorgiWalkState : CorgiGroundState
{
    public CorgiWalkState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
    {
    }

    public override void EnterState() {
        base.EnterState();
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void Update() {
        base.Update();
        if (!corgi.IsMoving()) {
            stateMachine.ChangeState(corgi.idleState);
        }
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
        Walk();
    }

    private void Walk() {
        corgi.SetVelocity(corgi.walkSpeed * corgi.inputDirection.x);
    }
}
