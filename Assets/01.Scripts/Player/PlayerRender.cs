using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRender : ConnectScript
{
    public void Direction(Vector2 point)
    {
        Vector3 direction = (Vector3)point - transform.position;
        Vector3 result = Vector3.Cross(Vector2.up, direction); //Vector3.Cross = 외적, 외적은 좌우 판별할 때 유용

        _spriteRenderer.flipX = result.z > 0;
    }
}
