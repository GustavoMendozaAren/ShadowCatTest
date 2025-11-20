using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RataEnemyIA : MonoBehaviour
{
    [SerializeField] private float velocidad = 3.6f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Collider2D colliderVida;
    [SerializeField] private GameObject rataParentObj;
    [SerializeField] private GameObject rataAtackCollider;
    [SerializeField] private RataLife rataLife;
    
    private Animator animator;
    private Vector3 originPosition;
    private Vector3 movePosition;
    private Vector3 moveDirection = Vector3.left;
    private PlayerDamage playerDamage;
    private bool canPatroll = true;
    private bool isRunning = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerDamage = FindObjectOfType<PlayerDamage>();

        originPosition = transform.position;
        originPosition.x += 7f;

        movePosition = transform.position;
        movePosition.x -= 7f;
    }

    void Update()
    {
        if (!playerDamage.IsPlayerDead)
        {
            if (!rataLife.IsDead)
            {
                CheckifCanPatroll();

                if (canPatroll)
                {
                    Patrullar();
                }

                if (isRunning)
                {
                    MovimientoDeAtaqueCarga();
                }
            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.ResetTrigger("Dead");
                animator.SetTrigger("Dead");
            }
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    void CheckifCanPatroll()
    {
        //Debug.DrawRay(transform.position, moveDirection * 5f);
        if (!Physics2D.Raycast(transform.position, moveDirection, 5f, playerLayer))
        {
            canPatroll = true;
            isRunning = false;
            animator.ResetTrigger("Charge");
            animator.SetBool("IsWalking", true);
            animator.SetBool("Run", false);
            animator.SetBool("IsAttacking", false);
        }
        else
        {
            canPatroll = false;

            CheckifCanAttack();
        }
    }

    void CheckifCanAttack()
    {
        //Debug.DrawRay(transform.position, moveDirection * 1.2f);
        if (!Physics2D.Raycast(transform.position, moveDirection, 1.2f, playerLayer))
        {
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsWalking", false);
            animator.SetTrigger("Charge");
        }
        else
        {
            isRunning = false;
            animator.ResetTrigger("Charge");
            animator.SetBool("Run", false);
            animator.SetBool("IsAttacking", true); 
        }
    }

    void Patrullar()
    {
        transform.Translate(velocidad * Time.deltaTime * moveDirection * StateGameController.enemiesTime);

        if (transform.position.x >= originPosition.x)
        {
            moveDirection = Vector3.left;

            ChangeDirection(-4f);

        }
        else if (transform.position.x <= movePosition.x)
        {
            moveDirection = Vector3.right;

            ChangeDirection(4f);
        }
    }

    void MovimientoDeAtaqueCarga()
    {
        transform.Translate(6f * Time.deltaTime * moveDirection * StateGameController.enemiesTime);
    }

    void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;

        tempScale.x = direction;

        transform.localScale = tempScale;
    }

    // METODOS DE EVENTOS EN ANIMACIONES

    void ActivarRunAnimation()
    {
        animator.SetBool("Run", true);
        isRunning = true;
    }

    void ActivarColliderVida()
    {
        colliderVida.enabled = true;
    }

    void DesactivarColliderVida()
    {
        colliderVida.enabled = false;
    }

    void ActivarDesactivarColliderAtaque()
    {
        rataAtackCollider.SetActive(!rataAtackCollider.activeSelf);
    }

    void RataMuerta()
    {
        Destroy(rataParentObj);
    }
}
