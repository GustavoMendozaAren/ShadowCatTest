using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerObj : MonoBehaviour
{
    [SerializeField] private GameObject dialoguesUI;
    [SerializeField] private SwitchLite playerMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialoguesUI.SetActive(true);
            playerMove.isInCinematic = true;
        }
    }
}
