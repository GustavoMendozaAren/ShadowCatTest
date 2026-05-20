using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObj : MonoBehaviour
{
    [SerializeField] private GameObject dialoguesUI;
    [SerializeField] private SwitchLite playerMove;

    [SerializeField] private GameObject barrerasNormales;
    [SerializeField] private GameObject barrerasBossFight;
    [SerializeField] private GameObject cosasLevelNormal;
    [SerializeField] private GameObject proteccionBotones;
    [SerializeField] private bool isLockBarreras = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLockBarreras)
        {
            dialoguesUI.SetActive(true);
            playerMove.isInCinematic = true;
        }
        else if (collision.CompareTag("Player") && isLockBarreras)
        {
            barrerasNormales.SetActive(false);
            barrerasBossFight.SetActive(true);
            proteccionBotones.SetActive(true);
            cosasLevelNormal.SetActive(false);
            gameObject.SetActive(false);
        }

    }
}
