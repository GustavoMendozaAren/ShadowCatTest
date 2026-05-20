using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderThrowAttack : MonoBehaviour
{
    [SerializeField] private SwitchLite playerMove;
    [SerializeField] private PlayerDamage playerLife;
    [SerializeField] private HealthBarBartender healthBartender;
    [SerializeField] private GameObject bottle1Prefab;
    [SerializeField] private GameObject bottle2Prefab;
    [SerializeField] private GameObject bottle3Prefab;
    [SerializeField] private GameObject bottle4Prefab;
    [SerializeField] private GameObject bottle5Prefab;
    [SerializeField] private Transform throwPoint;

    private Transform player;
    private float timer;

    public float throwCooldown = 1f;

    public bool IsAimingAtPlayer { get; set; }
    public bool CanThrow { get; set; } = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        ThrowBotlle();
    }

    private void Update()
    {
        if (playerLife.IsPlayerDead)
            return;

        if (healthBartender.IsBartenderDead)
            return;

        if (!playerMove.isInCinematic)
            TimerMethod();
    }

    private void TimerMethod()
    {
        if (CanThrow)
        {
            timer += Time.deltaTime;

            if (timer > throwCooldown)
            {
                ThrowBotlle();
                timer = 0;
            }
        }
    }

    private void ThrowBotlle()
    {
        float randomValue = Random.Range(0,100);
        GameObject prefabToThrow;

        if (randomValue >= 0 && randomValue < 15)
        {
            prefabToThrow = bottle1Prefab;
        }
        else if (randomValue >= 15 && randomValue < 45)
        {
            prefabToThrow = bottle2Prefab;
        }
        else if (randomValue >= 45 && randomValue < 70)
        {
            prefabToThrow = bottle3Prefab;
        }
        else if (randomValue >= 70 && randomValue < 90)
        {
            prefabToThrow = bottle4Prefab;
        }
        else if (randomValue >= 90 && randomValue < 100)
        {
            prefabToThrow = bottle5Prefab;
        }
        else
        {
            prefabToThrow = bottle3Prefab;
        }

        GameObject bottleObj = Instantiate(prefabToThrow, throwPoint.position, Quaternion.identity);

        Bottle1 bottle = bottleObj.GetComponent<Bottle1>();

        Vector2 direction;

        if (!IsAimingAtPlayer)
        {
            direction = transform.localScale.x > 0 ? Vector2.left : Vector2.right;
        }
        else
        {
            direction = (player.position - throwPoint.position).normalized;
        }

        bottle.SetDirection(direction);
    }
}
