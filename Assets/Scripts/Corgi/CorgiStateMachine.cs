using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiStateMachine
{
    public CorgiState CurrentState { get; private set; }

    public void InitState(CorgiState startingState) {
        CurrentState = startingState;
        CurrentState.EnterState();
    }

    public void ChangeState(CorgiState newState) {
        CurrentState.ExitState();
        CurrentState = newState;
        newState.EnterState();
    }
}
