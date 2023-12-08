using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class CorgiJumpState : CorgiState
{
    public CorgiJumpState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
    {
    }

    public override void EnterState() {
        base.EnterState();
        corgi.rb.velocity = new Vector2(corgi.rb.velocity.x, corgi.jumpForce);
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void Update() {
        base.Update();
        stateMachine.ChangeState(corgi.airState);
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }
}
