using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("�÷��̾� ��ġ")]
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed = 100;
    [SerializeField] private float _accel;
    [SerializeField] private float _deAccel;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _dashPower;

    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D _rb;

    private bool isDash = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Movement(Vector2 value)
    {
        if (value.sqrMagnitude > 0)
        {
            if (Vector3.Dot(_direction, value) < 0)
            {
                _speed = 0;
            }
            _direction = value;
            _direction.y = transform.position.y;
        }
        _speed = CalculateSpeed(value);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _direction);
    }

    private float CalculateSpeed(Vector2 moveInput)
    {
        if (moveInput != Vector2.zero)
        {
            _speed += _accel * Time.deltaTime;
        }
        else if (_speed >= 0)
        {
            _speed -= _deAccel * Time.deltaTime;
        }

        return Mathf.Clamp(_speed, 0, _maxSpeed);
    }

    public void Jump(bool isJump)
    {
        //    if (!isJump)
        //        _jumpPower = 0;
        //    else
        //        _jumpPower = JumpPower;

        //_isJumped = isJump;
    }

    private void FixedUpdate()
    {
        if (isDash)
            _rb.velocity = _direction.normalized * _dashPower;
        else
            _rb.velocity = new Vector2(_direction.x * _speed, _rb.velocity.y);
    }
}
