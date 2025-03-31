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
        SceneManager.LoadScene(2);
        StateGameController.sceneNo = 1;
    }

    public void PlayLeve2()
    {
        SceneManager.LoadScene(3);
        StateGameController.sceneNo = 2;
    }
    public void PlayLeve3()
    {
        SceneManager.LoadScene(5);
        StateGameController.sceneNo = 3;
    }

    public void PlayLeve4()
    {
        SceneManager.LoadScene(6);
        StateGameController.sceneNo = 4;
    }
    public void PlayLeve5()
    {
        SceneManager.LoadScene(6);
        StateGameController.sceneNo = 5;
    }

    public void PlayLeve6()
    {
        SceneManager.LoadScene(6);
        StateGameController.sceneNo = 6;
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

    // SMALL AND BIG BUTTONS

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

    public void Leve2BigBack()
    {
        buttons[2].SetActive(true);
        buttons[3].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void Level3Small()
    {
        buttons[4].SetActive(false);
        buttons[5].SetActive(true);
        blackCourtine.SetActive(true);
    }

    public void Level3BigBack()
    {
        buttons[4].SetActive(true);
        buttons[5].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void Level4Small()
    {
        buttons[6].SetActive(false);
        buttons[7].SetActive(true);
        blackCourtine.SetActive(true);
    }

    public void Level4BigBack()
    {
        buttons[6].SetActive(true);
        buttons[7].SetActive(false);
        blackCourtine.SetActive(false);
    }
    public void Level5Small()
    {
        buttons[8].SetActive(false);
        buttons[9].SetActive(true);
        blackCourtine.SetActive(true);
    }
    public void Level5BigBack()
    {
        buttons[8].SetActive(true);
        buttons[9].SetActive(false);
        blackCourtine.SetActive(false);
    }
    public void Level6Small()
    {
        buttons[10].SetActive(false);
        buttons[11].SetActive(true);
        blackCourtine.SetActive(true);
    }
    public void Level6BigBack()
    {
        buttons[10].SetActive(true);
        buttons[11].SetActive(false);
        blackCourtine.SetActive(false);
    }
}
