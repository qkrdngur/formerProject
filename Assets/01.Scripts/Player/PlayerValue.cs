using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValue : MonoBehaviour
{
    [Header("�÷��̾� bool ��")]
    public bool IsGround;
    public bool IsWalk;
    public bool IsDash;
    public bool IsJump;

    [Header("�÷��̾� ������ �Ӽ�")]
    public float _speed;
    public float _runSpeed;
    public float _jumpPower;
}
