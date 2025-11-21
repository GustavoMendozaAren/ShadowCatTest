using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarACallejones : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer entrarCallejon;
    [SerializeField] private GameObject spriteMensaje;
    [SerializeField] private GameObject escenarioNormal;
    [SerializeField] private GameObject escenarioCallejones1;
    [SerializeField] private bool tieneMensaje;

    private bool isInAvenue = true;
    private bool isInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;

            if(tieneMensaje)
                spriteMensaje.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;

            if (tieneMensaje)
                spriteMensaje.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (isInRange)
        {
            if (isInAvenue)
            {
                isInAvenue = false;
                escenarioNormal.SetActive(false);
                escenarioCallejones1.SetActive(true);
            }
            else
            {
                isInAvenue = true;
                escenarioNormal.SetActive(true);
                escenarioCallejones1.SetActive(false);
            }
        }
    }
}
