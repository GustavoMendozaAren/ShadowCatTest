using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearCallejones : MonoBehaviour
{
    [SerializeField] private GameObject callejonesCollidersObj;
    [SerializeField] private GameObject[] lightsFarolas;

    private void Start()
    {
        if (StateGameController.nivelDesbloqueado[2])
        {
            ActivarCallejonesYLuces();
        }
    }

    private void ActivarCallejonesYLuces()
    {
        callejonesCollidersObj.SetActive(true);

        for (int i = 0; i < lightsFarolas.Length; i++)
        {
            lightsFarolas[i].SetActive(true);
        }
    }
}
