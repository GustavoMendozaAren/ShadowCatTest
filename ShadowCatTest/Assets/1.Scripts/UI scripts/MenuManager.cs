using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainBttn, mainImg;
    public GameObject optiosBttn, optionsImg;
    public GameObject creditsBttn, creditsImg;
    public GameObject photosImages;

    public GameObject blackCourtine, pointers;
    public GameObject[] smallButtons, bigButtons;

    /*public void PlayGame()
    {
        SceneManager.LoadScene("VideoScena");
    }*/

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainBttn()
    {
        mainBttn.SetActive(false);
        mainImg.SetActive(true);
        optiosBttn.SetActive(true);
        optionsImg.SetActive(false);
        creditsBttn.SetActive(true);
        creditsImg.SetActive(false);
        photosImages.SetActive(true);
    }

    public void OptionsBttn()
    {
        mainBttn.SetActive(true);
        mainImg.SetActive(false);
        optiosBttn.SetActive(false);
        optionsImg.SetActive(true);
        creditsBttn.SetActive(true);
        creditsImg.SetActive(false);
        photosImages.SetActive(true);
    }

    public void CreditsBttn()
    {
        mainBttn.SetActive(true);
        mainImg.SetActive(false);
        optiosBttn.SetActive(true);
        optionsImg.SetActive(false);
        creditsBttn.SetActive(false);
        creditsImg.SetActive(true);
        photosImages.SetActive(false);

        pointers.SetActive(true);
        CreditsButtonsRestart();
    }

    public void CreditsButtonsRestart()
    {
        for (int j = 0; j < bigButtons.Length; j++)
        {
            smallButtons[j].SetActive(true);
        }
        for (int i = 0; i < bigButtons.Length; i++)
        {
            bigButtons[i].SetActive(false);
        }
        blackCourtine.SetActive(false);
    }

    public void MainProgrammerBttn1()
    {
        smallButtons[0].SetActive(false);
        bigButtons[0].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void MainProgrammerBttn2()
    {
        smallButtons[0].SetActive(true);
        bigButtons[0].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void MainArtistBttn1_1()
    {
        smallButtons[1].SetActive(false);
        bigButtons[1].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void MainArtistBttn2_1()
    {
        smallButtons[1].SetActive(true);
        bigButtons[1].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void MainArtistBttn1_2()
    {
        smallButtons[2].SetActive(false);
        bigButtons[2].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void MainArtistBttn2_2()
    {
        smallButtons[2].SetActive(true);
        bigButtons[2].SetActive(false);
        blackCourtine.SetActive(false);
    }
    public void ComposerBttn1()
    {
        smallButtons[3].SetActive(false);
        bigButtons[3].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void ComposerBttn2()
    {
        smallButtons[3].SetActive(true);
        bigButtons[3].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void ChuyBttn1_1()
    {
        smallButtons[4].SetActive(false);
        bigButtons[4].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void ChuyBttn2_1()
    {
        smallButtons[4].SetActive(true);
        bigButtons[4].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void ChuyBttn1_2()
    {
        smallButtons[5].SetActive(false);
        bigButtons[5].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void ChuyBttn2_2()
    {
        smallButtons[5].SetActive(true);
        bigButtons[5].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void ChuyBttn1_3()
    {
        smallButtons[6].SetActive(false);
        bigButtons[6].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void ChuyBttn2_3()
    {
        smallButtons[6].SetActive(true);
        bigButtons[6].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void JJBttn1_1()
    {
        smallButtons[7].SetActive(false);
        bigButtons[7].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void JJBttn2_1()
    {
        smallButtons[7].SetActive(true);
        bigButtons[7].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void JJBttn1_2()
    {
        smallButtons[8].SetActive(false);
        bigButtons[8].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void JJBttn2_2()
    {
        smallButtons[8].SetActive(true);
        bigButtons[8].SetActive(false);
        blackCourtine.SetActive(false);
    }

    public void JJBttn1_3()
    {
        smallButtons[9].SetActive(false);
        bigButtons[9].SetActive(true);
        pointers.SetActive(false);
        blackCourtine.SetActive(true);
    }

    public void JJBttn2_3()
    {
        smallButtons[9].SetActive(true);
        bigButtons[9].SetActive(false);
        blackCourtine.SetActive(false);
    }
}
