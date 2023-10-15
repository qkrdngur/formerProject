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
        // 스크린 좌표, 월드 좌표, 뷰포트좌표
        Vector3 mousePos = Input.mousePosition;  //스크린 포지션의 마우스 좌표를 알아와.
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
