using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : Singleton<GameInput>
{
    public PlayerInputActions InputActions => inputActions;
    private PlayerInputActions inputActions;
    public Player player;
    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    protected override void Awake()
    {
        base.Awake();
        inputActions = new PlayerInputActions();
    }

}
