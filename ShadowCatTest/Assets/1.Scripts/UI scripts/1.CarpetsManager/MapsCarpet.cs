using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapsCarpet : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] panels;
    public GameObject mapsMenu, nydeactivate, nyActive;
    public Animator comingSoon;
    public GameObject blackCourtine;

    public void PlayLevel1()
    {
        SceneManager.LoadScene("VideoScena");
    }

    public void PlayLeve2()
    {
        SceneManager.LoadScene("SampleScene Jacob");
    }
    public void PlayLeve3()
    {
        comingSoon.SetTrigger("Coming");
    }

    public void PlayLeve4()
    {
        comingSoon.SetTrigger("Coming");
    }


    public void MapsPanel()
    {
        panels[0].SetActive(true);

        mapsMenu.SetActive(false);
        nydeactivate.SetActive(true);
        nyActive.SetActive(false);
    }

    public void NYPanel()
    {
        panels[0].SetActive(false);

        mapsMenu.SetActive(true);
        nydeactivate.SetActive(false);
        nyActive.SetActive(true);
    }

    public void City2Panel()
    {
        comingSoon.SetTrigger("Coming");
    }

    public void City3Panel()
    {
        comingSoon.SetTrigger("Coming");
    }

    public void Level1Small()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(true);
        blackCourtine.SetActive(true);
    }

    public void Level1Big()
    {
        buttons[0].SetActive(true);
        buttons[1].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void Level2Small()
    {
        buttons[2].SetActive(false);
        buttons[3].SetActive(true);
        blackCourtine.SetActive(true);
    }

    public void Leve21Big()
    {
        buttons[2].SetActive(true);
        buttons[3].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void Level3Small()
    {
        comingSoon.SetTrigger("Coming");
    }

    /*public void Level3Big()
    {
        buttons[4].SetActive(true);
        buttons[5].SetActive(false);
    }*/

    public void Level4Small()
    {
        comingSoon.SetTrigger("Coming");
    }

    /*public void Level4Big()
    {
        buttons[6].SetActive(true);
        buttons[7].SetActive(false);
    }*/
}
