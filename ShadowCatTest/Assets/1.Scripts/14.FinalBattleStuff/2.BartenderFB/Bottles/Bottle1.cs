using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle1 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 360f;

    private Vector2 moveDirection = Vector2.left;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke(nameof(DestroyBottle), 5f);
    }

    private void Update()
    {
        // Movimiento
        rb.velocity = moveDirection * speed;

        // Rotacion
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerDamage playerDamage = FindFirstObjectByType<PlayerDamage>();
            playerDamage.DealDamageQuantity(0.15f);
            DestroyBottle();
        }
    }

    private void DestroyBottle()
    {
        Destroy(gameObject);
    }
}
