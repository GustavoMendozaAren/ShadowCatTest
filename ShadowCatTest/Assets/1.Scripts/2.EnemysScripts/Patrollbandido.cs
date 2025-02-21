using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrollbandido : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D MyBody;
    private Animator Anim;

    private Vector3 moveDirection = Vector3.right;
    private Vector3 originPosition;
    private Vector3 movePosition;
    private Vector3 FireBallRot;
    private bool canMove = true;

    private bool canShoot = true;

    public GameObject FireBall;
    public LayerMask playerLayer;

    public GameObject Exclamacion;

    private Coroutine co;

    //Scripts
    public PlayerDamage PDS;


    //Light
    public LightEnemy LES;

    //Life
    private float enemyLife = 2f;

    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 5f;

        movePosition = transform.position;
        movePosition.x -= 5f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        PlayerDead();
        Anim.speed = StateGameController.enemiesTime;
    }

    void MoveEnemy()
    {
        if(!Physics2D.Raycast(transform.position, moveDirection, 7f, playerLayer) && canMove)
        {
            Exclamacion.SetActive(false);
            transform.Translate(moveSpeed * Time.deltaTime * moveDirection * StateGameController.enemiesTime);
            //Debug.DrawRay(transform.position, moveDirection * 7f);
            if ( transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;
                FireBallRot = new Vector3(0, 0, 180f);

                ChangeDirection(-3.3f);
                
            }
            else if(transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
                FireBallRot = new Vector3(0, 0, 0);

                ChangeDirection(3.3f);
            }
            Anim.SetBool("Walk", true);
        }
        else
        {
            EnemyAttack();
            canMove = false;
            Anim.SetBool("Walk", false);
        }
    }

    void EnemyAttack()
    {
            
            Exclamacion.SetActive(true);
            if (canShoot)
            {
                canShoot = false;

                co = StartCoroutine(ShootAnim());
            }
            else
            {
                Anim.SetBool("Shoot", false);
            }
    }

    /*void CheckCollision()
    {
        if (!Physics2D.Raycast(GroundCollision.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }*/

    void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;

        tempScale.x = direction;

        transform.localScale = tempScale;
    }

    private IEnumerator ShootAnim()
    {
        yield return new WaitForSeconds(1.1f);
        
        Anim.SetBool("Shoot", true);
        yield return new WaitForSeconds(.2f);
        //Debug.Log("Shoot");
        GameObject bullet = Instantiate(FireBall, transform.position, Quaternion.Euler(FireBallRot));
        bullet.GetComponent<FireBallEnemy>().Speed *= transform.localScale.x;
        canShoot = true;
        canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
    }

    //Da�o por balas
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Bullet"))
        {
            //enemyLife = enemyLife - StateGameController.bulletPower;
            enemyLife = enemyLife - StateGameController.revolverPower;
            if (enemyLife > 0)
            {
                Debug.Log("EnemyHit");
                AudioManager.instance.PlayOneShot(FMODEvents.instance.EnemyHit, this.transform.position);
            }
            if (enemyLife <= 0)
            {
                enemyLife = 0;
            }
            if(enemyLife == 0)
            {
                if (co != null)
                {
                    StopCoroutine(co);
                }
                LES.DimLight = true;
                Anim.SetBool("Death", true);
                moveSpeed = 0f;
                GetComponent<Patrollbandido>().enabled = false;
                Invoke(nameof(DeactivateEnemy), 0.8f);
                AudioManager.instance.PlayOneShot(FMODEvents.instance.EnemyDead, this.transform.position);
                //Debug.Log("EnemyDead");
            }
        }
    }

    void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }

    void PlayerDead()
    {
        if (PDS.PlayerDead)
        {
            if (co != null)
            {
                StopCoroutine(co);
            }
            this.enabled = false;
        }
    }
}
