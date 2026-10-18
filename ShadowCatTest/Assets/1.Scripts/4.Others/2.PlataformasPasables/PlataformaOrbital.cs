using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaOrbital : MonoBehaviour
{
    [SerializeField] private Transform pivot; // Arrastra el objeto padre aquí
    [SerializeField] private float speed = 30f; // Grados por segundo

    void FixedUpdate()
    {
        // Orbita alrededor del pivot sin rotar sobre sí misma
        transform.RotateAround(pivot.position, Vector3.back, speed * Time.deltaTime);

        // Mantiene la orientación original
        transform.rotation = Quaternion.identity;
    }
}
