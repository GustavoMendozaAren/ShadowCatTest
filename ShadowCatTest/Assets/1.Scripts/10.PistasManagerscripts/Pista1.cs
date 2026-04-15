using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista1 : MonoBehaviour
{
    [SerializeField] private GameObject[] pistaPaneles;
    [SerializeField] private GameObject masInfoPanel;

    [SerializeField] private GameObject[] levelUnlocks;

    private void Start()
    {
        PanelesDePistasActivacionMetodo();
        ChecarNivelesDesbloqueados();
        //ChequeoDePistaRecolectada();
        
    }

    private void ChequeoDePistaRecolectada() 
    {
        // Evita que se carguen los paneles al iniciar el juego, en la primera iteracion
        if(StateGameController.sceneNo>0)
            PanelesDePistasActivacionMetodo();
    }

    private void PanelesDePistasActivacionMetodo() 
    {
        if (StateGameController.pistaCandado[0])
        { 
            StateGameController.nivelDesbloqueado[0] = true;

            pistaPaneles[0].SetActive(true);

            StateGameController.pistaCandado[0] = false;
        }
        if (StateGameController.pistaCandado[1])
        {
            StateGameController.nivelDesbloqueado[1] = true;

            pistaPaneles[1].SetActive(true);

            StateGameController.pistaCandado[1] = false;
        }
        if (StateGameController.pistaCandado[2])
        {
            StateGameController.nivelDesbloqueado[2] = true;

            pistaPaneles[2].SetActive(true);
            StateGameController.pistaCandado[2] = false;
        }
        if (StateGameController.pistaCandado[3])
        {
            StateGameController.nivelDesbloqueado[2] = true;

            masInfoPanel.SetActive(true);
            StateGameController.pistaCandado[3] = false;
        }
    }

    private void ChecarNivelesDesbloqueados()
    {
        if (StateGameController.nivelDesbloqueado[0])
        {
            //Debug.Log($"Nivel {i} desbloqueado");
            levelUnlocks[0].SetActive(true);
        }
        if (StateGameController.nivelDesbloqueado[1])
        {
            //Debug.Log($"Nivel {i} desbloqueado");
            levelUnlocks[1].SetActive(true);
        }
        if (StateGameController.nivelDesbloqueado[2])
        {
            //Debug.Log($"Nivel {i} desbloqueado");
            levelUnlocks[2].SetActive(true);
        }
    }

    public void ClosePistaPanelBttn()
    {
        pistaPaneles[StateGameController.sceneNo - 1].SetActive(false);
    }

    public void CloseMoreInfoPanel()
    {
        masInfoPanel.SetActive(false);
    }
}
