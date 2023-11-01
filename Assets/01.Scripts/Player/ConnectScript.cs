using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConnectScript : MonoBehaviour
{
    protected PlayerValue _playerValue;
    protected Rigidbody2D _rb;
    protected InputControl _playerInput;
    protected Animator _animator;
    protected SpriteRenderer _spriteRenderer;

    protected virtual void Awake()
    {
        _playerValue = transform.parent.parent.GetComponent<PlayerValue>();
        _rb = transform.parent.parent.GetComponent<Rigidbody2D>();
        _playerInput = transform.parent.parent.GetComponent<InputControl>();
        _spriteRenderer = transform.parent.parent.Find("Visual").GetComponent<SpriteRenderer>();
        _animator = transform.parent.parent.Find("Visual").GetComponent<Animator>();
    }
}
