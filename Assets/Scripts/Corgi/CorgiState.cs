using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiState
{
    protected Corgi corgi;
    protected CorgiStateMachine stateMachine;
    protected string animBoolName;

    public CorgiState(Corgi corgi, CorgiStateMachine stateMachine, string animBoolName) {
        this.corgi = corgi;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    
    public virtual void EnterState() {
        corgi.anim.SetBool(animBoolName, true);
    }

    public virtual void ExitState() {
        corgi.anim.SetBool(animBoolName, false);
    }

    public virtual void Update() {
        
    }

    public virtual void FixedUpdate() {

    }
}
