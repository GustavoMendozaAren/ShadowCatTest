using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter0 : MonoBehaviour
{
    public BGMusicManager bgMsc;

    public GameObject skipButton;
    public void ChapterCero()
    {
        //bgMsc.MusicToGo();
        skipButton.SetActive(true);
        gameObject.SetActive(false);
    }

}
