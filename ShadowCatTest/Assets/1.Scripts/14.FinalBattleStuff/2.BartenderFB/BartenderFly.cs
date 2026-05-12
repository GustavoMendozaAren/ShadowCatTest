using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderFly : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float arrivedDistance = 6f;
    [SerializeField] private float targetChangeTime = 3f;
    [SerializeField] private float moveSpeed = 3f;

    private float flyXRadius = 7f;
    private float flyYRadius = 7f;
    private Vector2 targetPosition;
    private float timer;
    private float distance;

    private void Start()
    {
        ChooseNewTargetPosition();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        MoveToTarget();
        LookAtPlayer();

        distance = Vector2.Distance(transform.position, targetPosition);

        if (distance <= arrivedDistance || timer >= targetChangeTime)
        {
            ChooseNewTargetPosition();
            timer = 0f;
        }
    }

    private void ChooseNewTargetPosition()
    {
        float randomX = Random.Range(-flyXRadius, flyXRadius);
        float randomY = Random.Range(6f, flyYRadius);
        Vector2 randomOffset = new Vector2(randomX, randomY);
        targetPosition = (Vector2)player.position + randomOffset;
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void LookAtPlayer()
    {
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(-0.9f, 0.9f, 0.9f);
        else
            transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }
}
