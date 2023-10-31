using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValue : MonoBehaviour
{
    [Header("플레이어 bool 값")]
    public bool IsGround;
    public bool IsWalk;
    public bool IsDash;
    public bool IsJump;

    [Header("플레이어 움직임 속성")]
    public float _speed;
    public float _runSpeed;
    public float _jumpPower;
}
