using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DoubleTap : MonoBehaviour
{

    public GameObject Button;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 2)
            {
                //Double tap
                Button.SetActive(true);
            }
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene Jacob");
    }
}
