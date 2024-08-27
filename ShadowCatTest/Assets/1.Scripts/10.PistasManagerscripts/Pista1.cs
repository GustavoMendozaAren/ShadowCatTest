using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista1 : MonoBehaviour
{
    public GameObject[] pistaPaneles;
    public GameObject[] closePistaPanelBttn;

    public GameObject[] levelUnlocks;

    private int _pistaNo;

    private void Start()
    {
        _pistaNo = StateGameController.sceneNo;
        if (StateGameController.pista1)
        {
            PanelesActivacionMetodo();
        }
        if (StateGameController.pista2)
        {
            PanelesActivacionMetodo();
        }
        if (StateGameController.pista3)
        {
            PanelesActivacionMetodo();
        }
        if (StateGameController.pista4)
        {
            PanelesActivacionMetodo();
        }
        if (StateGameController.pista5)
        {
            PanelesActivacionMetodo();
        }
        if (StateGameController.pista6)
        {
            PanelesActivacionMetodo();
        }
    }

    private void PanelesActivacionMetodo() 
    {
        pistaPaneles[_pistaNo - 1].SetActive(true);
        closePistaPanelBttn[_pistaNo - 1].SetActive(true);
        levelUnlocks[_pistaNo - 1].SetActive(true);
    }

    public void ClosePista1PanelBttn()
    {
        pistaPaneles[_pistaNo - 1].SetActive(false);
    }
}
