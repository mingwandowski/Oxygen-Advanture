using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiRunState : CorgiGroundState
{
    public CorgiRunState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
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
        Run();
    }

    private void Run() {
        corgi.SetVelocity(corgi.runSpeed * corgi.inputDirection.x);
    }
}
