using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1 : MonoBehaviour
{
    public BGMusicManager bgMsc;
    public void ChapterCero()
    {
        bgMsc.MusicToGo();
        gameObject.SetActive(false);
    }

}
