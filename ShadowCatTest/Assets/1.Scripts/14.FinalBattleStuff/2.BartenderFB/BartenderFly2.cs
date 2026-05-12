using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderFly2 : MonoBehaviour
{
    [SerializeField] private PatrollBoxArea areaPatroll;
    [SerializeField] private Transform playerTransform;

    [Header("Comportamiento")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float waypointRadius = 3f;
    [SerializeField] private float playerAvoidRadius = 2f;
    [SerializeField] private float playerHoverRadius = 4f;

    private Vector2 targetPoint;
    private bool hasTarget;

    private void Start()
    {
        PickNewTarget();
    }

    private void Update()
    {
        MoveTowardsTarget();
        AvoidPlayer();
        FlipTowardsPlayer();
    }

    void MoveTowardsTarget()
    {
        if (!hasTarget) return;

        transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint) < waypointRadius)
            PickNewTarget();
    }

    void PickNewTarget()
    {
        Vector2 candidate;
        int attempts = 0;

        do
        {
            candidate = playerHoverRadius > 0 && playerTransform != null ? GetPointAroundPlayer() : areaPatroll.GetRandomPoint();
            attempts++;
        }
        while (playerTransform != null && Vector2.Distance(candidate, playerTransform.position) < playerAvoidRadius && attempts < 10);

        targetPoint = candidate;
        hasTarget = true;
    }

    Vector2 GetPointAroundPlayer()
    {
        // Punto aleatorio dentro del radio de acoso
        Vector2 randomOffset = Random.insideUnitCircle * playerHoverRadius;
        Vector2 candidate = (Vector2)playerTransform.position + randomOffset;

        // Lo clampea para que no salga del BoxCollider2D
        return areaPatroll.Clamp(candidate);
    }

    void AvoidPlayer()
    {
        Vector2 toEnemy = (Vector2)transform.position - (Vector2)playerTransform.position;
        float distance = toEnemy.magnitude;

        if (distance < playerAvoidRadius && distance > 0.01f)
        {
            // Empuja al enemigo hacia afuera del radio cada frame
            Vector2 pushDirection = toEnemy.normalized;
            float pushStrength = 1f - (distance / playerAvoidRadius); // mas fuerte cuanto mas cerca
            transform.position += (Vector3)(pushDirection * pushStrength * moveSpeed * Time.deltaTime);
        }
    }

    void FlipTowardsPlayer()
    {
        float dirX = playerTransform.position.x - transform.position.x;
        Vector3 scale = transform.localScale;
        scale.x = dirX < 0 ? 1 : -1;
        transform.localScale = scale;
    }
}
