using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasillosCollider : MonoBehaviour
{
    public GameObject Letras;
    public GameObject Escena1, Escena2;
    public GameObject ButtonEnter, ButtonExit;

    //public WriteText writeText;
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Letras.SetActive(true);
            //writeText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Letras.SetActive(false);
            //writeText.enabled = false;

        }
    }

    public void EnterButton()
    {
        Escena1.SetActive(false);
        Escena2.SetActive(true);
        ButtonEnter.SetActive(false);
        ButtonExit.SetActive(true);
    }

    public void ExitButton()
    {
        Escena1.SetActive(true);
        Escena2.SetActive(false);
        ButtonEnter.SetActive(true);
        ButtonExit.SetActive(false);
    }
}
