using TMPro;
using UnityEngine;

public class EntrarACallejones : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer entrarCallejon;
    [SerializeField] private GameObject spriteMensaje;
    [SerializeField] private GameObject escenarioNormal;
    [SerializeField] private GameObject escenarioCallejones;
    [SerializeField] private GameObject textoAvenida;
    [SerializeField] private GameObject textoCallejon;
    [SerializeField] private Animator entrarPanel;
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
                escenarioCallejones.SetActive(true);

                textoAvenida.SetActive(false);
                textoCallejon.SetActive(true);

                entrarPanel.SetTrigger("FadeOut");
            }
            else
            {
                isInAvenue = true;
                escenarioNormal.SetActive(true);
                escenarioCallejones.SetActive(false);

                textoAvenida.SetActive(true);
                textoCallejon.SetActive(false);

                entrarPanel.SetTrigger("FadeOut");
            }
        }
    }
}
