using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : MonoBehaviour
{
    private float speed = 18f;
    private float lifeTime = 2f;
    private Vector3 temp;

    public float Speed 
    { 
        get { return speed; } 
        set { speed = value; } 
    }

    void Start()
    {
        temp = transform.position;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("RatEnemy") || collision.CompareTag("FinalBoss"))
        {
            Destroy(gameObject);
        }
    }
}
