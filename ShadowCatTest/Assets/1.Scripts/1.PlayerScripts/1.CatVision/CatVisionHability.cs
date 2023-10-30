using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CatVisionHability : MonoBehaviour
{
    public GameObject catPlatfomrsGroup;
    public GameObject catVisionPanel;

    Animator visionCatAnim;

    public CinemachineVirtualCamera vcam;
    float counter = 0f;

    bool camTrans = false;

    private void Awake()
    {
        visionCatAnim = catVisionPanel.GetComponent<Animator>();
    }
    void Start()
    {
        StateGameController.isCat = false;
    }

    private void Update()
    {
        if (StateGameController.isCat)
        {
            camTrans = true;
            counter += 2f * Time.deltaTime;
            visionCatAnim.SetBool("VisionCat", true);
            catPlatfomrsGroup.SetActive(true);
            vcam.m_Lens.OrthographicSize = 6.5f + counter;
            if (counter > 1f)
                counter = 1f;

            
            //vcam.m_Lens.OrthographicSize = Mathf.SmoothDamp(6.5f, 7.5f,ref yVelocity, 2f);
        }
        else
        {
            
            visionCatAnim.SetBool("VisionCat", false);
            catPlatfomrsGroup.SetActive(false);

            if (camTrans)
            {
                //counter = 1f;
                counter -= 2f * Time.deltaTime;
                vcam.m_Lens.OrthographicSize = 6.5f + counter;
                if (counter < 0f)
                    counter = 0f;
                //camTrans = false;
            }
            
            //vcam.m_Lens.OrthographicSize = Mathf.SmoothDamp(7.5f, 6.5f, ref yVelocity, 2f);
            //catVisionPanel.SetActive(false);
        }
        //Debug.Log(vcam.m_Lens.OrthographicSize);
    }
}
