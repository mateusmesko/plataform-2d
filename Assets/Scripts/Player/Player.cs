using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimento")]
    public Rigidbody2D rigidbody2D;
    public Vector2 friction = new Vector2(.1f, 0);

    public SO_PLAYER player;
    [Header("Anima��o")]
    public Animator animator;
    public string runTrigger = "Run";
    public string idleTrigger = "Idle";

    private float _currentSpeed;
    private bool facingRight = true; // Controle da dire��o

    private void Update()
    {
        HandleMoviment();
        HandleJump();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = player.run;
        else
            _currentSpeed = player.speed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(-_currentSpeed, rigidbody2D.velocity.y);

            // Vira para esquerda se necess�rio
            if (facingRight)
                Flip();

            if (animator != null)
                animator.SetTrigger(runTrigger);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(_currentSpeed, rigidbody2D.velocity.y);

            // Vira para direita se necess�rio
            if (!facingRight)
                Flip();

            if (animator != null)
                animator.SetTrigger(runTrigger);
        }
        else
        {
            animator.SetTrigger(idleTrigger);
        }

        // Fric��o
        if (rigidbody2D.velocity.x > 0)
            rigidbody2D.velocity += friction;
        else if (rigidbody2D.velocity.x < 0)
            rigidbody2D.velocity -= friction;
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody2D.velocity = Vector2.up * player.jump;
    }

    // Inverte o personagem
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
