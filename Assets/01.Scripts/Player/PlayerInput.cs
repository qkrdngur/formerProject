using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [Header("함수 연결")]
    [SerializeField] private UnityEvent<Vector2> OnMovement = null;
    [SerializeField] private UnityEvent OnDash = null;
    [SerializeField] private UnityEvent OnJump = null;

    [Header("스크립트 연결")]
    [SerializeField] private CinemachineVirtualCamera Vcam = null;

    //private CameraManager CameraManagerCompo = null;

    private void Awake()
    {
        CameraManager.Instance = new CameraManager(transform, Vcam);
    }
    private void Start()
    {
        _inputReader.MovementEvent += OnHandleMovement;
        _inputReader.JumpEvent += OnHandleJump;
        _inputReader.DashEvent += OnHandleDash;
    }

    private void OnHandleDash()
    {
        //    Debug.Log("OnHandleDash");
        //    Vector2 mousePos = CameraManager.Instance.Maincam.ScreenToWorldPoint(value);
            OnDash?.Invoke();
    }
    private void OnHandleJump(bool value)
    {
        if (value == true)
        {
            OnJump?.Invoke();
        }
    }

    private void OnHandleMovement(Vector2 value)
    {
        OnMovement?.Invoke(value);
    }
    private void OnDestroy()
    {
        _inputReader.MovementEvent -= OnHandleMovement;
        _inputReader.JumpEvent -= OnHandleJump;
        _inputReader.DashEvent -= OnHandleDash;
    }
}
