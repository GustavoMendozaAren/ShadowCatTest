using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasUIManager : MonoBehaviour
{
    [Header("REVOLVER BALAS")]
    [SerializeField] private GameObject revolverImg;
    [SerializeField] private GameObject balasRevolverParent;
    [SerializeField] private GameObject extraBalasRevolverParent;
    [SerializeField] private GameObject[] revolverBalasLlenas;

    [Header("ECOPETA BALAS")]
    [SerializeField] private GameObject escopetaImg;
    [SerializeField] private GameObject balasEscopetaParent;
    [SerializeField] private GameObject[] escopetaBalasLlenas;
    [SerializeField] private GameObject bulletsTypesParent;

    private int revolverBalasIndex = 0;
    private int escopetaBalasIndex = 3;

    public int RevolverBalasIndex
    {
        get { return revolverBalasIndex; }
        set { revolverBalasIndex = value; }
    }

    public int EscopetaBalasIndex
    {
        get { return escopetaBalasIndex; }
        set { escopetaBalasIndex = value; }
    }

    private void Start()
    {
        revolverBalasIndex = StateGameController.bulletsInGame - 1;
    }

    public void ActivarDesactivarBalasRevolver(bool state)
    {
        revolverImg.SetActive(state);
        balasRevolverParent.SetActive(state);
        extraBalasRevolverParent.SetActive(state);
    }

    public void RemoverBalasRevolver()
    {
        revolverBalasLlenas[revolverBalasIndex].SetActive(false);
        revolverBalasIndex--;
    }

    public void AgregarBalasRevolver()
    {
        revolverBalasIndex++;

        if (revolverBalasIndex >= StateGameController.bulletsInGame - 1)
        {
            revolverBalasIndex = StateGameController.bulletsInGame - 1;
        }

        revolverBalasLlenas[revolverBalasIndex].SetActive(true);
    }

    public void ActivarDesactivarBalasEscopeta(bool state)
    {
        escopetaImg.SetActive(state);
        balasEscopetaParent.SetActive(state);
    }

    public void RemoverBalasEscopeta()
    {
        escopetaBalasLlenas[escopetaBalasIndex].SetActive(false);
        escopetaBalasIndex--; 
    }

    public void AgregarBalasEscopeta()
    {
        escopetaBalasIndex++;

        if (escopetaBalasIndex >= 3)
            escopetaBalasIndex = 3;

        escopetaBalasLlenas[escopetaBalasIndex].SetActive(true);
    }

    public void ActivarDesactivarTodasLasBalas(bool state)
    {
        bulletsTypesParent.SetActive(state);
    }
}
