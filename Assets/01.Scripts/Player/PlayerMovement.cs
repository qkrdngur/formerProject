using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private float dashPower = 10;

    [SerializeField] private LayerMask WhatIsGround;

    private Vector2 direction = Vector2.zero;

    private bool isDash = false;
    private void Awake()
    {
        _rb = (Rigidbody2D)GetComponent("Rigidbody2D");
    }
    private void FixedUpdate()
    {
        if (isDash)
            _rb.velocity = direction.normalized * dashPower;
        else
            _rb.velocity = new Vector2(direction.x * speed, _rb.velocity.y);
    }
    public void Dash()
    {
        //StopImmediately();
        //OnConnect_Movement(value);
        if (!isDash)
        {
            //_rb.AddForce(direction.normalized * dashPower, ForceMode2D.Impulse);
        }

        StartCoroutine(DashCotoutine());
    }

    private IEnumerator DashCotoutine()
    {
        isDash = true;
        yield return new WaitForSeconds(0.3f);
        StopImmediately();
        isDash = false;

    }

    public void OnConnect_Jump()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 1f, WhatIsGround))
            _rb.velocity = Vector3.up * jumpPower;
    }
    public void OnConnect_Movement(Vector2 value)
    {
        direction = value;
    }

    public void StopImmediately()
    {
        direction = Vector2.zero;
    }

}
