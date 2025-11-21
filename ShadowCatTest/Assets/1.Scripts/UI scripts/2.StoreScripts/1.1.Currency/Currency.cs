using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    [SerializeField] private GameObject needCoinsPanel, currencyPanel;
    [SerializeField] private GameObject playVideoBttn, playVideoColdDownImg;
    //[SerializeField] private GameObject googlePlayPaymentPanel;
    //[SerializeField] private GameObject comingSoonTxt;
    [SerializeField] private GameObject yourAddImg;

    // ComingSoonTxt Aviable
    private bool canAppearCCT = true;

    // AD
    public GameObject videoCDObj, continueRewardBttn;
    private TMP_Text coinsText;

    private void Start()
    {
        coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
    }

    // NEED COINS PANEL

    public void NCBackBttnNeedCoinsPanel()
    {
        needCoinsPanel.SetActive(false);
    }

    // CURRENCY PANEL

    public void CPOpenBttnCurrencyPanel()
    {
        needCoinsPanel.SetActive(false);
        currencyPanel.SetActive(true);
    }

    public void CPBackBttnCurrencyPanel()
    {
        needCoinsPanel.SetActive(true);
        currencyPanel.SetActive(false);
    }

    public void CPPlayVideoBttnCurrencyPanel()
    {
        yourAddImg.SetActive(true);
        videoCDObj.SetActive(true);
        StartCoroutine(TimeToCloseAdd());
    }

    //public void CPPayBttnCurencyPanel()
    //{
    //    googlePlayPaymentPanel.SetActive(true);
    //}

    // GOOGLE PLAY PAYMENT PANEL

    //public void GPPPBackPaymentBttn()
    //{
    //    googlePlayPaymentPanel.SetActive(false);
    //}

    //public void GPPBuyPaymentBttn()
    //{
    //    if (canAppearCCT)
    //    {
    //        canAppearCCT = false;
    //        comingSoonTxt.SetActive(true);
    //        StartCoroutine(ComingSoonTxt());
    //    }
    //}

    // COORUTINAS

    IEnumerator TimeToCloseAdd()
    {
        yield return new WaitForSeconds(6f);
        videoCDObj.SetActive(false);
        continueRewardBttn.SetActive(true);
    }

    IEnumerator PlayVideoColdDown()
    {
        yield return new WaitForSeconds(60f);
        playVideoColdDownImg.SetActive(false);
        playVideoBttn.SetActive(true);
    }

    //IEnumerator ComingSoonTxt()
    //{
    //    yield return new WaitForSeconds(2f);
    //    comingSoonTxt.SetActive(false);
    //    canAppearCCT = true;
    //}

    // CONTINUE REWARD BUTTON

    public void ContinueRWButton()
    {
        continueRewardBttn.SetActive(false);
        yourAddImg.SetActive(false);

        // Reward Adquiered
        StateGameController.coinsTotal += 10;
        coinsText.text = StateGameController.coinsTotal.ToString();

        // Video Bttns and coorutine
        playVideoColdDownImg.SetActive(true);
        playVideoBttn.SetActive(false);
        StartCoroutine(PlayVideoColdDown());
    }

    // INSTAGRAM LINKS

    public void OpenURLPogrammer()
    {
        Application.OpenURL("https://gustavomdza-gamedev.itch.io/");
    }

    public void OpenURLComposer()
    {
        Application.OpenURL("https://www.instagram.com/rumo.doodle/");
    }

    public void OpenURLArtist()
    {
        Application.OpenURL("https://www.instagram.com/yam.yell.3/");
    }
}
