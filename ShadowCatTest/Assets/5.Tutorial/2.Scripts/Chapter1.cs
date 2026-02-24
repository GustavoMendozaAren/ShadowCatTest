using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1 : MonoBehaviour
{
    [SerializeField] private GameObject dialogosPanel;
    [SerializeField] private bool tieneDialogos = false;

    public BGMusicManager bgMsc;

    public void ChapterCero()
    {
        bgMsc.MusicToGo();

        if (tieneDialogos)
            dialogosPanel.SetActive(true);

        gameObject.SetActive(false);
    }

}
