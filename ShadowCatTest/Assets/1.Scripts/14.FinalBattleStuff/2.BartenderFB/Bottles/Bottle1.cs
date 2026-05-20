using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle1 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private bool[] isBottle;
    [SerializeField] private GameObject prefab;

    private Vector2 moveDirection = Vector2.left;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isBottle[0])
        {
            float randomTime = Random.Range(2.8f, 5.2f);
            Invoke(nameof(DestroyVenenoBottle), randomTime);
        }   
        else
            Invoke(nameof(DestroyBottle), 8f);
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
            DamageByBottleType();
        }
    }

    private void DamageByBottleType()
    {
        if (isBottle[0])
        {
            DestroyVenenoBottle();
        }
        else if (isBottle[1])
        {
            PlayerDamage playerDamage = FindFirstObjectByType<PlayerDamage>();
            playerDamage.DealDamageQuantity(0.25f);
            DestroyBottle();
        }
        else if (isBottle[2])
        {
            PlayerDamage playerDamage = FindFirstObjectByType<PlayerDamage>();
            playerDamage.DealDamageQuantity(0.5f);
            DestroyBottle();
        }
        else if (isBottle[3])
        {
            PlayerDamage playerDamage = FindFirstObjectByType<PlayerDamage>();
            playerDamage.GainHealth(0.25f);
            DestroyBottle();
        }
        else if (isBottle[4])
        {
            PlayerDamage playerDamage = FindFirstObjectByType<PlayerDamage>();
            playerDamage.GainHealth(1f);
            DestroyBottle();
        }
    }

    private void DestroyVenenoBottle()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void DestroyBottle()
    {
        Destroy(gameObject);
    }
}
