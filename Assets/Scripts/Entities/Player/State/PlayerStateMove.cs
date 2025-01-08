using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerStateMove : PlayerState
{

    private Vector2 directionVector;
    private Vector3 deltaPosition;
    private float lastRotation;
    public PlayerStateMove(Player player, StateMachine<PlayerState> stateMachine) : base(player, stateMachine)
    {
        lastRotation = 0;
    }

    public override void CheckStateChange()
    {
        if (!player.IsMovementPressed)
        {
            stateMachine.TransitionTo(new PlayerStateIdle(player, stateMachine));
        }
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
        player.transform.DORotate(new Vector3(0, 0, lastRotation), 0f);
    }

    public override void Tick()
    {
        directionVector = player.MovementInput;

        if (player.transform.position.x == MainCamera.Instance.MinMoveableBounds.x && directionVector.x < 0
        || player.transform.position.x == MainCamera.Instance.MaxMoveableBounds.x && directionVector.x > 0)
        {
            // Can not move only on the X
            directionVector = new Vector3(0f, directionVector.y).normalized;
        }

        if (player.transform.position.y == MainCamera.Instance.MinMoveableBounds.y && directionVector.y < 0
        || player.transform.position.y == MainCamera.Instance.MaxMoveableBounds.y && directionVector.y > 0)
        {
            // Can not move only on the Y
            directionVector = new Vector3(directionVector.x, 0f).normalized;
        }

        deltaPosition = directionVector * player.MoveSpeed * Time.deltaTime;

        Vector2 newPos = new Vector2();

        //Limit the movement of player in the area of boundary
        newPos.x = Mathf.Clamp(player.transform.position.x + deltaPosition.x, MainCamera.Instance.MinMoveableBounds.x, MainCamera.Instance.MaxMoveableBounds.x);
        newPos.y = Mathf.Clamp(player.transform.position.y + deltaPosition.y, MainCamera.Instance.MinMoveableBounds.y, MainCamera.Instance.MaxMoveableBounds.y);

        player.transform.position = newPos;

        if (player.MovementInput.magnitude != 0)
        {
            Rotate();
        }

        CheckStateChange();
    }

    public void Rotate()
    {
        float targetAngle = Mathf.Atan2(player.MovementInput.y, player.MovementInput.x) * Mathf.Rad2Deg - 90;

        lastRotation = targetAngle;

        player.transform.DORotate(new Vector3(0, 0, targetAngle), 0.25f);

    }
}
