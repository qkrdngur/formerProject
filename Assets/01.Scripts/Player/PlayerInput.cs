using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [Header("�Լ� ����")]
    [SerializeField] private UnityEvent<Vector2> OnMovement = null;
    [SerializeField] private UnityEvent OnDash = null;
    [SerializeField] private UnityEvent OnJump = null;

    [Header("��ũ��Ʈ ����")]
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

    private void OnHandleDash(bool value)
    {
        //    Debug.Log("OnHandleDash");
        //    Vector2 mousePos = CameraManager.Instance.Maincam.ScreenToWorldPoint(value);
        if (value == true)
        {
            OnDash?.Invoke();
        }
        else if (value == false)
        {

        }
    }
    private void OnHandleJump(bool value)
    {
        if (value == true)
        {
            OnJump?.Invoke();
        }
        else if (value == false)
        {

        }
    }

    private void OnHandleMovement(Vector2 value)
    {
        Debug.Log("��������");
        OnMovement?.Invoke(value);
    }
    private void OnDestroy()
    {
        _inputReader.MovementEvent -= OnHandleMovement;
        _inputReader.JumpEvent -= OnHandleJump;
        _inputReader.DashEvent -= OnHandleDash;
    }
}
