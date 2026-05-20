using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Patrolling, Charging }

public class BartenderFly2 : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private PlayerDamage playerLife;
    [SerializeField] private PatrollBoxArea areaPatroll;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private BartenderThrowAttack bartenderThrow;
    [SerializeField] private HealthBarBartender bartenderHealth;

    [Header("Embestida")]
    [SerializeField] private float chargeInterval = 20f;
    [SerializeField] private float chargeSpeed = 12f; // velocidad de la embestida
    [SerializeField] private float chargeDuration = 1.5f; // tiempo máximo volando hacia el jugador

    [Header("Comportamiento")]
    [SerializeField] private float waypointRadius = 3f;
    [SerializeField] private float playerAvoidRadius = 2f;
    [SerializeField] private float playerHoverRadius = 4f;
    public float moveSpeed = 6f;

    private Vector2 targetPoint;
    private bool hasTarget;

    // EMBESTIDA COSAS
    private EnemyState state = EnemyState.Patrolling;
    private float chargeTimer;
    private Vector2 chargeDirection;

    public bool CanCharge { get; set; } = false;

    private void Start()
    {
        PickNewTarget();
    }

    private void Update()
    {
        if (bartenderHealth.IsBartenderDead) return;

        if (!playerLife.IsPlayerDead)
        {
            if (CanCharge)
            {
                chargeTimer += Time.deltaTime;

                if (chargeTimer >= chargeInterval && state == EnemyState.Patrolling)
                    StartCharge();
            }
        }

        switch (state)
        {
            case EnemyState.Patrolling:
                bartenderThrow.CanThrow = true;
                MoveTowardsTarget();
                AvoidPlayer();
                break;
            case EnemyState.Charging:
                bartenderThrow.CanThrow = false;
                UpdateCharge();
                break;
        }

        if (playerTransform != null)
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

    void StartCharge()
    {
        state = EnemyState.Charging;
        chargeTimer = 0f;

        // Congela la dirección al momento de embestir, así aunque el
        // jugador se mueva la embestida sigue siendo esquivable
        chargeDirection = ((Vector2)playerTransform.position - (Vector2)transform.position).normalized;

        // Cancela el destino actual para que no interfiera
        hasTarget = false;

        StartCoroutine(EndChargeAfterDuration());
    }

    void UpdateCharge()
    {
        transform.position += (Vector3)(chargeDirection * chargeSpeed * Time.deltaTime);

        // Clampea para que no salga del área durante la embestida
        if (areaPatroll != null)
            transform.position = areaPatroll.Clamp(transform.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && state == EnemyState.Charging)
        {
            StopAllCoroutines();
            state = EnemyState.Patrolling;
            PickNewTarget();
        }
    }

    IEnumerator EndChargeAfterDuration()
    {
        yield return new WaitForSeconds(chargeDuration);
        state = EnemyState.Patrolling;
        PickNewTarget();
    }
}
