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

    [Header("ESCENA3")]
    [SerializeField] private GameObject bartenderSurp3;
    [SerializeField] private GameObject detectiveSurp3;
    [SerializeField] private GameObject bartenderNorm3;
    [SerializeField] private GameObject detectiveNorm3;
    [SerializeField] private GameObject[] dialogos3;
    private int id3;


    void Start()
    {
        id3 = 1;
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

    public void Escena2D3()
    {
        dialogos2[1].SetActive(false);
        dialogos2[2].SetActive(true);
    }

    public void Escena2D4End()
    {
        escenas[1].SetActive(false);
        escenas[2].SetActive(true);
        StartCoroutine(Escena3InicioSBFadeIn());
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

    IEnumerator Escena3InicioSBFadeIn()
    {
        yield return new WaitForSeconds(3f);
        dialogos3[0].SetActive(true);
    }

    public void Escena3D1()
    {
        bartenderSurp3.SetActive(false);
        bartenderNorm3.SetActive(true);
        dialogos3[0].SetActive(false);
        dialogos3[1].SetActive(true);
    }

    public void Escena3DN()
    {
        if (id3 < 12)
        {
            dialogos3[id3].SetActive(false);
            dialogos3[id3 + 1].SetActive(true);
        } else if (id3 >= 12)
        {
            escenas[2].SetActive(false);
            escenas[3].SetActive(true);
        }

        if (id3 == 1)
        {
            detectiveSurp3.SetActive(false);
            detectiveNorm3.SetActive(true);
        }

        id3++;
    }

    
}
