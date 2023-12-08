using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiAnimationState : CorgiState
{
    public CorgiAnimationState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
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
        // wait for 2 second
        // run to home
        // run back and disappear
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }
}
