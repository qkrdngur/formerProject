using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("플레이어 수치")]
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed = 100;
    [SerializeField] private float _accel;
    [SerializeField] private float _deAccel;
    [SerializeField] private float _jumpPower;

    private float JumpPower => _jumpPower;

    private bool _isJumped = false;

    private Vector2 _direction;
    private Rigidbody2D _rb;

    private bool _isjumped = false;

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

        _isJumped = isJump;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(transform.position, Vector3.down, .5f))
            {
                _rb.velocity = Vector3.up * _jumpPower;
            }
        }

       // _rb.velocity = _direction * _speed;
    }
}
