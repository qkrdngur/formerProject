using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovement = null;
    //public UnityEvent<bool> OnJumped = null;
    public UnityEvent<Vector2> OnCameraPoint = null;

    private bool _isJumped = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetJump();
        GetKeyInput();
        GetPointerInput();
    }

    private void GetPointerInput()
    {
        // ��ũ�� ��ǥ, ���� ��ǥ, ����Ʈ��ǥ
        Vector3 mousePos = Input.mousePosition;  //��ũ�� �������� ���콺 ��ǥ�� �˾ƿ�.
        mousePos.z = 0;
        Vector2 mouseInWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        OnCameraPoint?.Invoke(mouseInWorldPos);
    }

    private void GetJump()
    {
        //if (Physics2D.Raycast(transform.position, Vector3.down, .5f))
        //    _isJumped = true;
        //else
        //    _isJumped = false;

        //float j = Input.GetAxisRaw("Jump");

        //if (j == 0) _isJumped = false;
        //else _isJumped = true;

        //if(Input.GetKey(KeyCode.Space)) _isJumped = true;
        //else _isJumped=false;

        //OnJumped?.Invoke(_isJumped);
    }

    private void GetKeyInput()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 dir = new Vector2(x, 0);

        OnMovement?.Invoke(dir.normalized);
    }
}
