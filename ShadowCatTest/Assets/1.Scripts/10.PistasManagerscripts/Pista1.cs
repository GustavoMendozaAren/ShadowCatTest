using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista1 : MonoBehaviour
{
    public GameObject[] pistaPaneles;
    public GameObject[] closePistaPanelBttn;
    [SerializeField] private GameObject masInfoPanel;

    public GameObject[] levelUnlocks;
    //private bool[] levelKey = new bool[2];

    private void Start()
    {
        ChequeoDePistaRecolectada();
    }

    private void ChequeoDePistaRecolectada() 
    {
        if(StateGameController.sceneNo>0)
            PanelesActivacionMetodo();
    }

    private void PanelesActivacionMetodo() 
    {
        if (StateGameController.pistaAgarrada[0]) 
        {
            levelUnlocks[0].SetActive(true);
            if (StateGameController.pistaCandado[0])
            {
                pistaPaneles[0].SetActive(true);
                closePistaPanelBttn[0].SetActive(true);
                StateGameController.pistaCandado[0] = false;
            }
        }
        if (StateGameController.pistaCandado[1])
        {
            pistaPaneles[1].SetActive(true);
            closePistaPanelBttn[1].SetActive(true);
            StateGameController.pistaCandado[1] = false;
        }
        if (StateGameController.pistaCandado[2])
        {
            pistaPaneles[2].SetActive(true);
            closePistaPanelBttn[2].SetActive(true);
            StateGameController.pistaCandado[2] = false;
        }
        //if (numero < 1) 
        //{
        //    levelUnlocks[numero].SetActive(true);
        //}
    }

    private void ChecarNivelesDesbloqueados()
    {

    }

    public void ClosePistaPanelBttn()
    {
        pistaPaneles[StateGameController.sceneNo - 1].SetActive(false);
    }

    public void ActivarPanelMasInformacion()
    {
        pistaPaneles[StateGameController.sceneNo - 1].SetActive(false);
        masInfoPanel.SetActive(true);
    }

    public void CloseMoreInfoPanel()
    {
        masInfoPanel.SetActive(false);
    }
}
