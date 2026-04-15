using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUITriggerFB : MonoBehaviour
{
    [SerializeField] private GameObject textos;
    [SerializeField] private Animator detectiveAnim;
    [SerializeField] private Animator dialogoAnim;
    [SerializeField] private SwitchLite playerMove;
    [SerializeField] private GameObject dialogueTriggerObj;

    [SerializeField] private bool hasTriggerObj = false;
    

    public bool DialogueImgDeactive { get; set; }
    public bool DialogueAnimDeactive { get; set; }

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
        Invoke(nameof(DesactivarEsteObjeto), 1f);

        DialogueAnimDeactive = true;
    }

    private void DesactivarEsteObjeto()
    {
        playerMove.isInCinematic = false;

        if (hasTriggerObj)
            dialogueTriggerObj.SetActive(false);

        DialogueImgDeactive = true;

        gameObject.SetActive(false);
    }
}
