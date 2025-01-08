using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    public PlayerStateIdle(Player player, StateMachine<PlayerState> stateMachine) : base(player, stateMachine)
    {
    }

    public override void CheckStateChange()
    {
        if (player.IsMovementPressed)
        {
            stateMachine.TransitionTo(new PlayerStateMove(player, stateMachine));
        }

    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Tick()
    {
        player.Fire();
        CheckStateChange();
    }
}
