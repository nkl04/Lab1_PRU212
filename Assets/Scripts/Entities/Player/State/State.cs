
using UnityEngine;

public abstract class State
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Tick();
    public abstract void CheckStateChange();
}

public abstract class PlayerState : State
{
    protected Player player;

    protected StateMachine<PlayerState> stateMachine;

    public PlayerState(Player player, StateMachine<PlayerState> stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

}
