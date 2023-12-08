using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiIdleState : CorgiGroundState
{
    public CorgiIdleState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
    {
    }

    public override void EnterState() {
        base.EnterState();
        corgi.SetVelocity(0);
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void Update() {
        base.Update();
        if (corgi.IsMoving()) {
            stateMachine.ChangeState(corgi.runState);
        }
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }
}
