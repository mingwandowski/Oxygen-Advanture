using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiAirState : CorgiState
{
    public CorgiAirState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
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
        corgi.anim.SetFloat("yVelocity", this.corgi.rb.velocity.y);
        if (corgi.IsGrounded()) {
            stateMachine.ChangeState(corgi.idleState);
        }
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
        corgi.SetVelocity(corgi.runSpeed * corgi.inputDirection.x);
    }
}
