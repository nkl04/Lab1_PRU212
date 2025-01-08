using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> : MonoBehaviour where T : State
{
    private T currentState;

    public void TransitionTo(T newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Tick()
    {
        if (currentState != null)
        {
            currentState.Tick();
        }
    }
}
