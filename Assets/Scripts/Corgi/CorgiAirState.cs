using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiAirState : CorgiState
{
    public CorgiAirState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) : base(corgi, stateMachine, animBoolName)
    {
    }

    public override void EnterState() {
        Debug.Log("enter air state");
        base.EnterState();
        // corgi.GetComponent<Rigidbody2D>().sharedMaterial.friction = 0;
    }

    public override void ExitState() {
        Debug.Log("exit air state");
        base.ExitState();
        // corgi.GetComponent<Rigidbody2D>().sharedMaterial.friction = 0.2f;
    }

    public override void Update() {
        base.Update();
        Debug.Log("air state");
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
