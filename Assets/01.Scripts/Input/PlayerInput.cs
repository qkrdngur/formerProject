using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovement = null;
    public UnityEvent<Vector2> OnJumped = null;
    public UnityEvent<Vector2> OnCameraPoint = null;

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
        float j = Input.GetAxisRaw("Jump");

        Vector2 dir = new Vector2(0, j);

        OnJumped?.Invoke(dir);
    }

    private void GetKeyInput()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 dir = new Vector2(x, transform.position.y);

        OnMovement?.Invoke(dir.normalized);
    }
}
