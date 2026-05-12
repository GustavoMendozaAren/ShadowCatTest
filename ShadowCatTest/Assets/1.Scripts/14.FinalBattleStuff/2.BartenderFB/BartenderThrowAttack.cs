using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderThrowAttack : MonoBehaviour
{
    [SerializeField] private SwitchLite playerMove;
    [SerializeField] private HealthBarBartender healthBartender;
    [SerializeField] private GameObject bottle1Prefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float throwCooldown = 7f;

    private Transform player;
    private float timer;

    public bool IsAimingAtPlayer { get; set; }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        ThrowBotlle();
    }

    private void Update()
    {
        if (healthBartender.IsBartenderDead)
            return;

        if (!playerMove.isInCinematic)
            TimerMethod();
    }

    private void TimerMethod()
    {
        timer += Time.deltaTime;

        if (timer > throwCooldown)
        {
            ThrowBotlle();
            timer = 0;
        }
    }

    private void ThrowBotlle()
    {
        GameObject bottleObj = Instantiate(bottle1Prefab, throwPoint.position, Quaternion.identity);

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
