using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatVisiionTutorial : MonoBehaviour
{
    [SerializeField] GameObject mensajesGato;

    private void Update()
    {
        if (StateGameController.isCat)
        {
            mensajesGato.SetActive(true);
        }
    }
}
