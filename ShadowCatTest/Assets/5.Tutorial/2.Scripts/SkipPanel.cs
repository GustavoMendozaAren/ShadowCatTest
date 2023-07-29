using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipPanel : MonoBehaviour
{

    public GameObject skipButton;
    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void ActiveButton()
    {
        skipButton.SetActive(true);
    }

}
