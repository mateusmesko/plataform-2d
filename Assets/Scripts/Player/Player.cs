using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimento")]
    public Rigidbody2D rigidbody2D;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;


    private float _currentSpeed;

    private void Update()
    {
        HandleMoviment();
        HandleJump();

    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftArrow))
            rigidbody2D.velocity = new Vector2(-_currentSpeed, rigidbody2D.velocity.y);
        else if (Input.GetKey(KeyCode.RightArrow))
            rigidbody2D.velocity = new Vector2(_currentSpeed, rigidbody2D.velocity.y);

        if (rigidbody2D.velocity.x > 0)
            rigidbody2D.velocity += friction;
        else if (rigidbody2D.velocity.x < 0)
            rigidbody2D.velocity -= friction;
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody2D.velocity = Vector2.up * forceJump;
    }

}
