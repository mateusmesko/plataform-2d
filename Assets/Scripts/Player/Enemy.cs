using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";

    public SpriteRenderer spriteRenderer; // Referência ao SpriteRenderer
    public Color flashColor = Color.red;  // Cor do flash
    public float flashDuration = 0.2f;    // Tempo de cada piscada

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Projetel"))
        {
           
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
           

            Debug.Log("Colidiu com: " + collision.transform.name);

            PlayAttackAnimation();
            StartCoroutine(FlashAndDestroy());
        }
    }

    private void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerAttack);
        }
    }

    private IEnumerator FlashAndDestroy()
    {
        Color originalColor = spriteRenderer.color;
        float totalTime = 2f; // Total de tempo de flash em segundos
        float timer = 0f;

        while (timer < totalTime)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
            timer += flashDuration * 2;
        }

        Destroy(gameObject); // Destroi o inimigo após o flash
    }
}
