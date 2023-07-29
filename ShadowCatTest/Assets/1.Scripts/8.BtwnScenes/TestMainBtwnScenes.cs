using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestMainBtwnScenes : MonoBehaviour
{
    public GameObject escenario2;

    BtwnScenes btwnScenes;

    void Start()
    {
        btwnScenes = FindObjectOfType<BtwnScenes>();
        if (btwnScenes.testKey)
        {
            escenario2.SetActive(true);
        }
    }

}
