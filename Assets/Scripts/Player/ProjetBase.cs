using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetBase : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projétil
    public float projectileSpeed = 10f; // Velocidade do projétil
    public Transform shootPoint;        // Ponto de onde o projétil será lançado
    public KeyCode shootKey = KeyCode.Space; // Tecla para atirar

    public int facingDirection = 1; // 1 = direita, -1 = esquerda
    public int maxProjectiles = 10; // Máximo de projéteis ativos
    public float projectileLifetime = 2f; // Tempo de vida do projétil
    public float shootCooldown = 1f; // Cooldown de 1 segundo
    private float lastShootTime = -Mathf.Infinity;

    private Queue<GameObject> projectilesQueue = new Queue<GameObject>();

    private void Update()
    {
        // Verifica se apertou a tecla e se o cooldown passou
        if (Input.GetKeyDown(shootKey) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time; // Atualiza o momento do último disparo
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            // Instancia o projétil
            GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            // Define a velocidade dependendo da direção
            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(facingDirection * projectileSpeed, 0);
            }

            // Gira o projétil se estiver olhando para a esquerda
            if (facingDirection < 0)
            {
                proj.transform.localScale = new Vector3(-1, 1, 1);
            }

            // Adiciona o projétil na fila
            projectilesQueue.Enqueue(proj);

            // Destroi o projétil automaticamente após 'projectileLifetime' segundos
            Destroy(proj, projectileLifetime);

            // Limita a quantidade de projéteis na fila
            if (projectilesQueue.Count > maxProjectiles)
            {
                GameObject oldest = projectilesQueue.Dequeue();
                if (oldest != null)
                {
                    Destroy(oldest);
                }
            }
        }
    }
}
