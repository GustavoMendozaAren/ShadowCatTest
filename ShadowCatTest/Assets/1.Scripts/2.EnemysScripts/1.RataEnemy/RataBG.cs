using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataBG : MonoBehaviour
{
    [Header("TRANSFORMS")]
    [SerializeField] private Transform transformTrasero;
    [SerializeField] private Transform transformDelantero;

    [Header("VARIABLES")]
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float tiempoEntreApariciones = 5f;

    private Transform objetivoActual;
    private Animator animator;
    private float direccion;
    private SpriteRenderer spriteRenderer;
    private bool sePuedeMover;

    void Start()
    {
        sePuedeMover = true;
        objetivoActual = transformDelantero;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Correr();
    }

    void Mover()
    {
        animator.SetBool("IsWalking", true);
        transform.position = Vector2.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, objetivoActual.position) < 0.5f)
        {
            objetivoActual = (objetivoActual == transformTrasero) ? transformDelantero : transformTrasero;

            direccion = (objetivoActual.position.x > transform.position.x) ? 4f : -4f;
            ChangeDirection(direccion);
        }
    }

    void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;

        tempScale.x = direction;

        transform.localScale = tempScale;
    }

    void Correr()
    {
        if (sePuedeMover)
        {
            animator.SetBool("Run", true);
            transform.position = Vector2.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

            if (Vector2.Distance(transform.position, objetivoActual.position) < 0.5f)
            {
                sePuedeMover = false;
                spriteRenderer.enabled = false;
                transform.position = transformTrasero.position;
                StartCoroutine(ActivarParaCorrer());
                //gameObject.SetActive(false);
            }
        }
    }

    IEnumerator ActivarParaCorrer()
    {
        yield return new WaitForSeconds(tiempoEntreApariciones);
        spriteRenderer.enabled = true;
        sePuedeMover = true;
    }
}
