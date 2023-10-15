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

    private bool _isJumped = false;

    private Vector2 _direction;
    private Vector2 _jumpDirection;
    private Rigidbody2D _rb;

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

        }
        _speed = CalculateSpeed(value);
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

    public void Jump(Vector2 value)
    {
        _isJumped = true;
        _jumpDirection = value;
    }

    private void FixedUpdate()
    {
        if (_isJumped)
        {
            _rb.AddForce(_jumpDirection * _jumpPower, ForceMode2D.Impulse);
            _jumpDirection = Vector2.zero;
            _isJumped = false;
        }
        else
            _rb.velocity = _direction * _speed;
    }
}
