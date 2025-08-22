using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetBase : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do proj�til
    public float projectileSpeed = 10f; // Velocidade do proj�til
    public Transform shootPoint;        // Ponto de onde o proj�til ser� lan�ado
    public KeyCode shootKey = KeyCode.Space; // Tecla para atirar

    public int facingDirection = 1; // 1 = direita, -1 = esquerda
    public int maxProjectiles = 10; // M�ximo de proj�teis ativos
    public float projectileLifetime = 2f; // Tempo de vida do proj�til
    public float shootCooldown = 1f; // Cooldown de 1 segundo
    private float lastShootTime = -Mathf.Infinity;

    private Queue<GameObject> projectilesQueue = new Queue<GameObject>();

    private void Update()
    {
        // Verifica se apertou a tecla e se o cooldown passou
        if (Input.GetKeyDown(shootKey) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time; // Atualiza o momento do �ltimo disparo
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            // Instancia o proj�til
            GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            // Define a velocidade dependendo da dire��o
            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(facingDirection * projectileSpeed, 0);
            }

            // Gira o proj�til se estiver olhando para a esquerda
            if (facingDirection < 0)
            {
                proj.transform.localScale = new Vector3(-1, 1, 1);
            }

            // Adiciona o proj�til na fila
            projectilesQueue.Enqueue(proj);

            // Destroi o proj�til automaticamente ap�s 'projectileLifetime' segundos
            Destroy(proj, projectileLifetime);

            // Limita a quantidade de proj�teis na fila
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
