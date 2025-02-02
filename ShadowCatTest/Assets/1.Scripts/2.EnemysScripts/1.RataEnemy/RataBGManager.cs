using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataBGManager : MonoBehaviour
{
    [SerializeField] private GameObject rataPrefab;
    private bool activate = false;

    private void Update()
    {
        if (activate)
        {
            ActiveRataPrefab();
        }
    }

    public void ActivarRata()
    {
        activate = true;
    }

    IEnumerator ActiveRataPrefab()
    {
        yield return new WaitForSeconds(15f);
        rataPrefab.SetActive(true);
        activate = false;
    }
}
