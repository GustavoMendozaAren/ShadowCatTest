using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandidoPlatform : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
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

    //Platform
    private bool leftDir = true;

    public Transform GroundCheck;

    //Scripts
    public PlayerDamage PDS;


    //Light
    public LightEnemy LES;

    //Life
    private float enemyLife = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        /*originPosition = transform.position;
        originPosition.x += 5f;

        movePosition = transform.position;
        movePosition.x -= 5f;*/
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        GroundDetection();
        PlayerDead();
        Anim.speed = StateGameController.enemiesTime;
    }

    void MoveEnemy()
    {
        if (!Physics2D.Raycast(transform.position, moveDirection, 7f, playerLayer) && canMove)
        {
            Exclamacion.SetActive(false);
            //transform.Translate(moveSpeed * Time.deltaTime * moveDirection);
            if (leftDir)
            {
                //rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                transform.Translate(moveSpeed * Time.deltaTime * moveDirection * StateGameController.enemiesTime);
                FireBallRot = new Vector3(0, 0, 0);
                moveDirection = Vector3.right;
            }
            else
            {
                //rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                transform.Translate(moveSpeed * Time.deltaTime * moveDirection * StateGameController.enemiesTime);
                FireBallRot = new Vector3(0, 0, 180f);
                moveDirection = Vector3.left;
            }

            
            Debug.DrawRay(transform.position, moveDirection * 7f);
            /*if (transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;
                FireBallRot = new Vector3(0, 0, 180f);

                ChangeDirection();

            }
            else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
                FireBallRot = new Vector3(0, 0, 0);

                ChangeDirection();
            }*/
            Anim.SetBool("Walk", true);
        }
        else
        {
            EnemyAttack();
            canMove = false;
            Anim.SetBool("Walk", false);
        }
        
    }
    void GroundDetection()
    {
        if (!Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
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

    /*void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;

        tempScale.x = direction;

        transform.localScale = tempScale;
    }*/

    void ChangeDirection()
    {
        leftDir = !leftDir;

        Vector3 tempScale = transform.localScale;

        if (leftDir)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }

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
            enemyLife = enemyLife - StateGameController.revolverPower;
            if (enemyLife <= 0)
            {
                enemyLife = 0;
            }
            if (enemyLife == 0)
            {
                if (co != null)
                {
                    StopCoroutine(co);
                }
                LES.DimLight = true;
                Anim.SetBool("Death", true);
                moveSpeed = 0f;
                GetComponent<BandidoPlatform>().enabled = false;
                Invoke(nameof(DeactivateEnemy), 0.8f);
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
