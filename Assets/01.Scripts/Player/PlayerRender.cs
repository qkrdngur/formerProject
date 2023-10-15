using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRender : MonoBehaviour
{
    protected SpriteRenderer _spriteRenderer;

    protected virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Direction(Vector2 point)
    {
        Vector3 direction = (Vector3)point - transform.position;
        Vector3 result = Vector3.Cross(Vector2.up, direction); //Vector3.Cross = ����, ������ �¿� �Ǻ��� �� ����

        _spriteRenderer.flipX = result.z > 0;
    }
}
