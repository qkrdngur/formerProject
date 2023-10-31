using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum groundDir
{
    DOWN,
    LEFT,
    RIGHT,
    NONE
}
public abstract class MovementBrain : MonoBehaviour
{
    public LayerMask WhatIsGround;
    public Rigidbody2D _rb;

    public groundDir GroundEnum;

    public bool isDash = false;
    public bool isJump = false;

    public virtual void OnJump()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f, WhatIsGround))
            GroundEnum = groundDir.DOWN;
        else if (Physics2D.Raycast(transform.position, Vector2.right, 1f, WhatIsGround))
            GroundEnum = groundDir.RIGHT;
        else if (Physics2D.Raycast(transform.position, Vector2.left, 1f, WhatIsGround))
        {
            GroundEnum = groundDir.LEFT;
            Debug.Log("left");
        }
        else
            GroundEnum = groundDir.NONE;
    }
    public virtual void OnDash(){}
    public virtual void OnAttack(){}
}
