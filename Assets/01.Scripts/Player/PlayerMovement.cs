using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ConnectScript
{
    [SerializeField] private LayerMask _whatIsGround;

    private Vector2 _direction = Vector2.zero;
    private Vector2 _Movedirection = Vector2.zero;

    private float _currentSpeed;

    protected override void Awake()
    {
        base.Awake();

        _playerInput.OnMovement += OnMovement;
        _playerInput.OnJump += OnJump;
        _playerInput.OnDash += OnDash;
        _playerInput.OnAttack += OnAttack;
    }

    private void Update()
    {
        if (_playerValue.IsDash) _currentSpeed = _playerValue._runSpeed;
        else _currentSpeed = _playerValue._speed;

        if (!_playerValue.IsDash && Mathf.Abs(_direction.x) != 0) _playerValue.IsWalk = true;
        else _playerValue.IsWalk = false;

        CalculateMovement();
        Move();

        CheckGround();
    }

    public  void OnAttack()
    {

    }

    public  void OnDash()
    {
        _playerValue.IsDash = !_playerValue.IsDash;
    }

    public void OnMovement(Vector2 value)
    {
        _direction = value;
    }

    private void CalculateMovement()
    {
        _Movedirection = new Vector2(_direction.x * _currentSpeed, _rb.velocity.y);
    }

    private void Move()
    {
        if ((_playerValue.IsDash || _playerValue.IsWalk))
            _rb.velocity = _Movedirection;
        Debug.Log(_playerValue.IsGround);
        _animator.SetBool("grounded", _playerValue.IsGround);
        _animator.SetFloat("velocityX", Mathf.Abs(_direction.x) / _currentSpeed);
    }

    public  void OnJump()
    {
        if (_playerValue.IsGround)
        {
            _rb.AddForce(Vector2.up * _playerValue._jumpPower, ForceMode2D.Impulse);
        }
    }

    private void CheckGround()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, 2f, _whatIsGround))
            _playerValue.IsGround = true;
        else
            _playerValue.IsGround = false;
    }

    //좌우 벽점프 만들기
    //벽 vector에  * -1 = 오른쪽
}
