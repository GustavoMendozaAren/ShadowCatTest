using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetManager : MonoBehaviour
{
    public GameObject blockInteractions;
    public Animator Carpet1, Shadow1;
    public Animator carpet2, shadow2;
    public GameObject backBttn;

    public void NextCarpet()
    {
        Carpet1.SetBool("Carpet1", true);
        Shadow1.SetBool("Move", true);

        carpet2.SetBool("In", true);
        shadow2.SetBool("In", true);

        blockInteractions.SetActive(true);
        Invoke(nameof(BlockInteractionsNext), 2f);
    }

    public void PrevCarpet()
    {
        backBttn.SetActive(false);
        Shadow1.SetBool("Move", false);
        Carpet1.SetBool("Carpet1", false);

        carpet2.SetBool("In", false);
        shadow2.SetBool("In", false);

        blockInteractions.SetActive(true);
        Invoke(nameof(BlockInteractionsBack), 2f);
    }

    private void BlockInteractionsNext()
    {
        blockInteractions.SetActive(false);
        backBttn.SetActive(true);
    }
    private void BlockInteractionsBack()
    {
        blockInteractions.SetActive(false);
    }


    public void PestañasUISound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.pestañaUI, this.transform.position);
    }

}
