using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarACallejones2 : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer entrarCallejon;
    [SerializeField] private Animator spriteMensaje;
    [SerializeField] private GameObject escenarioActivado;
    [SerializeField] private GameObject EscenarioDesactivado;
    [SerializeField] private GameObject textoActivado;
    [SerializeField] private GameObject textoDesactivado;
    [SerializeField] private Animator entrarPanel;
    [SerializeField] private bool tieneMensaje;

    private bool isInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;

            if (tieneMensaje)
                spriteMensaje.SetBool("IsFadeIn", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;

            if (tieneMensaje)
                spriteMensaje.SetBool("IsFadeIn", false);
        }
    }
    private void OnMouseDown()
    {
        if (isInRange)
        {
            escenarioActivado.SetActive(true);
            EscenarioDesactivado.SetActive(false);

            textoActivado.SetActive(true);
            textoDesactivado.SetActive(false);

            entrarPanel.SetTrigger("FadeOut");
        }
    }
}
