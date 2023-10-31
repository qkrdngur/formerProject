using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CamPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> OnCameraPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        GetPointerInput();
    }

    private void GetPointerInput()
    {
        // ????? ???, ???? ???, ????????
        Vector3 mousePos = Input.mousePosition;  //????? ???????? ???²J ????? ????.
        mousePos.z = 0;
        Vector2 mouseInWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        OnCameraPoint?.Invoke(mouseInWorldPos);
    }
}
