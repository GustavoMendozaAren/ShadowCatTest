using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista1 : MonoBehaviour
{
    public GameObject pista1Panel, closePistaP1PanelBttn;

    public GameObject level2SmallBttn;

    private void Start()
    {
        if (StateGameController.pista1)
        {
            StartCoroutine(Pista1Timer());
            StateGameController.pista1 = false;
        }
        if (StateGameController.level2Key)
        {
            level2SmallBttn.SetActive(true);
        }
    }

    IEnumerator Pista1Timer()
    {
        pista1Panel.SetActive(true);
        yield return new WaitForSeconds(5f);
        closePistaP1PanelBttn.SetActive(true);
    }

    public void ClosePista1PanelBttn()
    {
        pista1Panel.SetActive(false);
    }

    public void Pista1Test()
    {
        StartCoroutine(Pista1Timer());
    }
}
