using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _velocity;

    private Vector2 _direction = Vector2.zero;
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
    }

    private void FixedUpdate()
    {

    }
}
