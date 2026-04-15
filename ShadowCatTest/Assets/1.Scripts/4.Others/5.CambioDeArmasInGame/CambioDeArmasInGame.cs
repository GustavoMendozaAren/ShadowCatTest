using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioDeArmasInGame : MonoBehaviour
{
    [SerializeField] private Image shootButtonImg;
    [SerializeField] private Sprite escopetaBtnImg;
    [SerializeField] private Sprite revolverBtnImg;
    

    [SerializeField] private GameObject botonesArmas;
    [SerializeField] private BalasUIManager balasUIManager;

    public void AbrirMenuDeAramas()
    {
        //if (StateGameController.isShotgunUnlock)
            botonesArmas.SetActive(true);
    }

    public void CerrarMenuDeArmas()
    {
        //if (StateGameController.isShotgunUnlock)
            botonesArmas.SetActive(false);
    }

    public void RevolverArma()
    {
        shootButtonImg.sprite = revolverBtnImg;

        balasUIManager.ActivarDesactivarBalasRevolver(true);
        balasUIManager.ActivarDesactivarBalasEscopeta(false);

        StateGameController.NumeroDeArmaEquipada = 0;
    }

    public void EscopetaArma()
    {
        shootButtonImg.sprite = escopetaBtnImg;

        balasUIManager.ActivarDesactivarBalasRevolver(false);
        balasUIManager.ActivarDesactivarBalasEscopeta(true);

        StateGameController.NumeroDeArmaEquipada = 1;
    }
}
