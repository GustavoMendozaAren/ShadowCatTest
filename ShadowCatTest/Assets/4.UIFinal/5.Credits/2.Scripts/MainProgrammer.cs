using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainProgrammer : MonoBehaviour
{
    public GameObject mainProgrammerBttn1, mainProgrammerBttn2;

    private Animation animMainProgrammer;

    private void Start()
    {
        animMainProgrammer = gameObject.GetComponent<Animation>();
    }
    public void MainProgrammerBttn1()
    {
        mainProgrammerBttn1.SetActive(false);
        mainProgrammerBttn2.SetActive(true);
        animMainProgrammer.Play();
    }

    public void MainProgrammerBttn2()
    {
        mainProgrammerBttn1.SetActive(true);
        mainProgrammerBttn2.SetActive(false);
        animMainProgrammer.Play();
    }
}
