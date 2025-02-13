using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject[] escenas;

    [Header("ESCENA1")]
    [SerializeField] private GameObject detectiveNormal;
    [SerializeField] private GameObject bartenderNormal;
    [SerializeField] private GameObject detectiveSorprendido;
    [SerializeField] private GameObject[] dialogos;

    [Header("ESCENA2")]
    [SerializeField] private GameObject velas;
    [SerializeField] private GameObject[] dialogos2;
    


    void Start()
    {
        StartCoroutine(Escena1D1());
    }

    IEnumerator Escena1D1()
    {
        escenas[0].SetActive(true);
        yield return new WaitForSeconds(4f);
        detectiveNormal.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialogos[0].SetActive(true);
    }

    public void Escena1D2()
    {
        bartenderNormal.SetActive(true);
        dialogos[0].SetActive(false);
        dialogos[1].SetActive(true);
    }

    public void Escena1D3()
    {
        dialogos[1].SetActive(false);
        dialogos[2].SetActive(true);
    }

    public void Escena1D4()
    {
        dialogos[2].SetActive(false);
        dialogos[3].SetActive(true);
    }

    public void Escena1D5()
    {
        dialogos[3].SetActive(false);
        dialogos[4].SetActive(true);
    }

    public void Escena1D6()
    {
        dialogos[4].SetActive(false);
        dialogos[5].SetActive(true);
    }

    public void Escena1D7()
    {
        dialogos[5].SetActive(false);
        detectiveSorprendido.SetActive(true);
    }

    public void Escena2D1()
    {
        escenas[0].SetActive(false);
        detectiveSorprendido.SetActive(false);
        StartCoroutine(Escena2Inicio());
    }

    public void Escena2D2()
    {
        dialogos2[0].SetActive(false);
        StartCoroutine(Escena2Velas());
    }

    public void Escena2D3End()
    {
        escenas[1].SetActive(false);
        escenas[2].SetActive(true);
    }

    IEnumerator Escena2Inicio()
    {
        escenas[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        dialogos2[0].SetActive(true);
    }

    IEnumerator Escena2Velas()
    {
        velas.SetActive(true);
        yield return new WaitForSeconds(4f);
        dialogos2[1].SetActive(true);
    }
}
