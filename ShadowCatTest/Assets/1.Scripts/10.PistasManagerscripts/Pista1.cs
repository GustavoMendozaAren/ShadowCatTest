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
        if (StateGameController.pista1 && StateGameController.candado[0] == 1)
        {
            StartCoroutine(Pista1Timer());
            levelUnlocks[0].SetActive(true);
        }
        if (StateGameController.pista2 && StateGameController.candado[1] == 1)
        {
            StartCoroutine(Pista1Timer());
            levelUnlocks[1].SetActive(true);
        }
        if (StateGameController.pista3 && StateGameController.candado[2] == 1)
        {
            StartCoroutine(Pista1Timer());
            levelUnlocks[2].SetActive(true);
        }
        if (StateGameController.pista4 && StateGameController.candado[3] == 1)
        {
            Debug.Log("PistaActivada");
            StartCoroutine(Pista1Timer());
            levelUnlocks[3].SetActive(true);
        }
        if (StateGameController.pista5 && StateGameController.candado[4] == 1)
        {
            StartCoroutine(Pista1Timer());
            levelUnlocks[4].SetActive(true);
        }
        if (StateGameController.pista6 && StateGameController.candado[5] == 1)
        {
            StartCoroutine(Pista1Timer());
        }
    }

    IEnumerator Pista1Timer()
    {
        Debug.Log("RutinaActivada");
        pistaPaneles[_pistaNo - 1].SetActive(true);
        yield return new WaitForSeconds(4f);
        closePistaPanelBttn[_pistaNo - 1].SetActive(true);
    }

    public void ClosePista1PanelBttn()
    {
        pistaPaneles[_pistaNo - 1].SetActive(false);
    }
}
