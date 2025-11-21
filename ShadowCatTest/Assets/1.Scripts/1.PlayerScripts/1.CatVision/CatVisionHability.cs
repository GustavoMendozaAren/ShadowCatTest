using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CatVisionHability : MonoBehaviour
{
    [SerializeField] private GameObject catPlatfomrsGroup;
    [SerializeField] private GameObject catVisionPanel;
    [SerializeField] private CinemachineVirtualCamera vcam;

    private Animator visionCatAnim;
    private float counter = 0f;
    private bool camTrans = false;

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
        VisionGato();
    }

    private void VisionGato()
    {
        if (StateGameController.isCat)
        {
            camTrans = true;
            counter += 2f * Time.deltaTime;
            visionCatAnim.SetBool("VisionCat", true);
            catPlatfomrsGroup.SetActive(true);
            vcam.m_Lens.OrthographicSize = 6.5f + counter;
            if (counter > 1f)
            {
                counter = 1f;
                vcam.m_Lens.OrthographicSize = 7.5f;
            }
        }
        else
        {

            visionCatAnim.SetBool("VisionCat", false);
            catPlatfomrsGroup.SetActive(false);

            if (camTrans)
            {
                counter -= 2f * Time.deltaTime;
                vcam.m_Lens.OrthographicSize = 6.5f + counter;
                if (counter < 0f)
                {
                    counter = 0f;
                    vcam.m_Lens.OrthographicSize = 6.5f;
                }
            }
        }
        //Debug.Log(vcam.m_Lens.OrthographicSize);
    }
}
