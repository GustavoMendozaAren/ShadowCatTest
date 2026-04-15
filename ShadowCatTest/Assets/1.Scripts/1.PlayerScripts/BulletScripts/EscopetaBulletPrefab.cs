using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscopetaBulletPrefab : MonoBehaviour
{
    private float speed = 22f;
    private float lifeTime = 1.5f;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("RatEnemy") || collision.CompareTag("FinalBoss"))
        {
            Destroy(gameObject);
        }
    }
}
