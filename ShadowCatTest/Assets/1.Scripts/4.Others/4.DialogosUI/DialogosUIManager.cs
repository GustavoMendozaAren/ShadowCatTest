using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosUIManager : MonoBehaviour
{
    [SerializeField] private GameObject textos;
    [SerializeField] private Animator detectiveAnim;
    [SerializeField] private Animator dialogoAnim;

    private void Start()
    {
        Invoke(nameof(ActivarTextos), 2.1f);
    }

    private void ActivarTextos()
    {
        textos.SetActive(true);
    }

    public void DesactivarDialogosAniamciones()
    {
        detectiveAnim.SetBool("IsExit", true);
        dialogoAnim.SetBool("IsFadeOut", true);
        Invoke(nameof(DesactivarDialogos), 1f);
    }

    private void DesactivarDialogos()
    {
        gameObject.SetActive(false);
    }
}
