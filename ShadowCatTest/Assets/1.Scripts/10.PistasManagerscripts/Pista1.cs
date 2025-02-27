using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista1 : MonoBehaviour
{
    public GameObject[] pistaPaneles;
    public GameObject[] closePistaPanelBttn;
    [SerializeField] private GameObject masInfoPanel;

    public GameObject[] levelUnlocks;

    private void Start()
    {
        ChequeoDePistaRecolectada();
    }

    private void ChequeoDePistaRecolectada() 
    {
        if(StateGameController.sceneNo>0)
            PanelesActivacionMetodo(StateGameController.sceneNo-1);
    }

    private void PanelesActivacionMetodo(int numero) 
    {
        pistaPaneles[numero].SetActive(true);
        closePistaPanelBttn[numero].SetActive(true);
        if (numero < 2) 
        {
            levelUnlocks[numero].SetActive(true);
        }
    }

    public void ClosePista1PanelBttn()
    {
        if (pistaPaneles[0])
        {
            masInfoPanel.SetActive(true);
            pistaPaneles[StateGameController.sceneNo - 1].SetActive(false);
        }
        else
        {
            pistaPaneles[StateGameController.sceneNo-1].SetActive(false);
        }
    }

    public void CloseMoreInfoPanel()
    {
        masInfoPanel.SetActive(false);
    }
}
