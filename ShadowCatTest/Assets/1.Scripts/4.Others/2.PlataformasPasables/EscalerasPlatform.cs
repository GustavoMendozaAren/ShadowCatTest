using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalerasPlatform : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCol;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCol.enabled = false;
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCol.enabled = true;
        }
    }
}
