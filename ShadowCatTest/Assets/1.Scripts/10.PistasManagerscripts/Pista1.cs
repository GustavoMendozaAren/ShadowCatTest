using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista1 : MonoBehaviour
{
    public GameObject[] pistaPaneles;
    public GameObject[] closePistaPanelBttn;

    public GameObject[] levelUnlocks;

    private void Start()
    {
        ChequeoDePistaRecolectada();
    }

    private void ChequeoDePistaRecolectada() 
    {
        if(StateGameController.sceneNo == 1)
            PanelesActivacionMetodo(StateGameController.sceneNo - 1);
    }

    private void PanelesActivacionMetodo(int numero) 
    {
        pistaPaneles[numero].SetActive(true);
        closePistaPanelBttn[numero].SetActive(true);
        levelUnlocks[numero].SetActive(true);
    }

    public void ClosePista1PanelBttn()
    {
        pistaPaneles[StateGameController.sceneNo - 1].SetActive(false);
    }
}
