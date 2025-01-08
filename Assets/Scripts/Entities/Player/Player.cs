using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Info")]
    [SerializeField]
    private float moveSpeed;
    public float fireRate = 0.5f;

    [Header("Components")]
    public Transform firePoint;
    public GameObject LazerPrefab;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public Rigidbody2D Rb2d { get; private set; }
    public Vector2 MovementInput { get; private set; }
    public bool IsMovementPressed { get; set; }
    public bool IsFirePressed { get; set; }
    private StateMachine<PlayerState> stateMachine;
    private GameInput gameInput;
    private float timeCounter;
    private void Awake()
    {

        Rb2d = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine<PlayerState>();                     // Create a new state machine

        stateMachine.TransitionTo(new PlayerStateIdle(this, stateMachine)); // Change the state to idle

        timeCounter = fireRate;
    }

    private void Start()
    {
        gameInput = GameInput.Instance;

        gameInput.InputActions.Player.Move.performed += OnMoveInput;

        gameInput.InputActions.Player.Move.canceled += OnMoveInput;

        gameInput.InputActions.Player.Fire.performed += OnFireInput;

        gameInput.InputActions.Player.Fire.canceled += OnFireInput;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>().normalized;

        IsMovementPressed = MovementInput.magnitude > 0;
    }

    private void OnFireInput(InputAction.CallbackContext context)
    {
        IsFirePressed = context.ReadValueAsButton();
    }

    private void Update()
    {
        stateMachine.Tick(); // Update the current state

        timeCounter -= Time.deltaTime;
    }

    public void Fire()
    {
        if (timeCounter <= 0)
        {
            GameObject lazerGameObj = ObjectPooler.Instance.GetObjectFromPool(LazerPrefab.name);
            if (lazerGameObj == null) return;
            lazerGameObj.transform.position = firePoint.position;
            lazerGameObj.transform.rotation = firePoint.rotation;
            lazerGameObj.SetActive(true);
            timeCounter = fireRate;
        }
    }
}
