using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControl : MonoBehaviour
{
    private InputSystem _inputAction;

    public event Action<Vector2> OnMovement;
    public event Action OnDash;
    public event Action OnJump;
    public event Action OnAttack;
    public event Action OnFirePos;

    private void Awake()
    {
        _inputAction = new InputSystem();
        _inputAction.Player.Enable();

        _inputAction.Player.Dash.performed += OnDashHandle;
        _inputAction.Player.Jump.performed += OnJumpHandle;
        _inputAction.Player.Attack.performed += OnAttackHandle;
        _inputAction.Player.FirePos.performed += OnFirePosHandle;
    }

    private void OnAttackHandle(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }

    private void OnDashHandle(InputAction.CallbackContext context)
    {
        OnDash?.Invoke();
    }
    private void OnJumpHandle(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private void OnFirePosHandle(InputAction.CallbackContext context)
    {
        OnFirePos?.Invoke();
    }

    private void Update()
    {
        Vector2 inputDir = _inputAction.Player.Movement.ReadValue<Vector2>();
        OnMovement.Invoke(inputDir);
    }
}