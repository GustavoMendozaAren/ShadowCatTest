using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataEnemyIA : MonoBehaviour
{
    [Header("TRANSFORMS")]
    [SerializeField] private Transform transformTrasero; 
    [SerializeField] private Transform transformDelantero;

    [Header("VARIABLES")]
    [SerializeField] private float velocidad = 2f; 

    private Transform objetivoActual; 
    private Animator animator;

    void Start()
    {
        objetivoActual = transformDelantero; 
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        animator.SetBool("IsWalking", true);
        transform.position = Vector2.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, objetivoActual.position) < 0.5f)
        {
            objetivoActual = (objetivoActual == transformTrasero) ? transformDelantero : transformTrasero;
            // Voltear sprite según la dirección del movimiento
            float direccion = (objetivoActual.position.x > transform.position.x) ? 4f : -4f;
            ChangeDirection(direccion);
        }
    }

    void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;

        tempScale.x = direction;

        transform.localScale = tempScale;
    }
}
