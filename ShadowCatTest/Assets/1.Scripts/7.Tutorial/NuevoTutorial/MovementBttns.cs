using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBttns : MonoBehaviour
{
    public float localPointA = -2.7f; // Primer punto local en el eje y
    public float localPointB = -3.3f; // Segundo punto local en el eje y
    public float speed = 0.35f;  // Velocidad de movimiento

    private bool movingUp = true;

    void Update()
    {
        // Si el objeto está subiendo
        if (movingUp)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, localPointB, transform.localPosition.z), speed * Time.deltaTime);

            // Si el objeto llega al punto B, cambia la dirección
            if (transform.localPosition.y == localPointB)
            {
                movingUp = false;
            }
        }
        // Si el objeto está bajando
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, localPointA, transform.localPosition.z), speed * Time.deltaTime);

            // Si el objeto llega al punto A, cambia la dirección
            if (transform.localPosition.y == localPointA)
            {
                movingUp = true;
            }
        }
    }
}
