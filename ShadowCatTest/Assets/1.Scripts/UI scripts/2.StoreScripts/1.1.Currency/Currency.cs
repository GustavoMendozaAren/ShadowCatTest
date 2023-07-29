using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public GameObject needCoinsPanel, currencyPanel;
    public GameObject playVideoBttn, playVideoColdDownImg;
    public GameObject googlePlayPaymentPanel, comingSoonTxt, yourAddImg;

    // ComingSoonTxt Aviable
    private bool canAppearCCT = true;

    // Ad
    public GameObject videoCDObj, continueRewardBttn;
    private TMP_Text coinsText;

    private void Start()
    {
        coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
    }

    // NeedCoinsPanel

    public void NCBackBttnNeedCoinsPanel()
    {
        needCoinsPanel.SetActive(false);
    }

    // CurencyPanel

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

    public void CPPayBttnCurencyPanel()
    {
        googlePlayPaymentPanel.SetActive(true);
    }

    // GooglePlayPaymentPanel

    public void GPPPBackPaymentBttn()
    {
        googlePlayPaymentPanel.SetActive(false);
    }

    public void GPPBuyPaymentBttn()
    {
        if (canAppearCCT)
        {
            canAppearCCT = false;
            comingSoonTxt.SetActive(true);
            StartCoroutine(ComingSoonTxt());
        }
    }

    // Coorutinas

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

    IEnumerator ComingSoonTxt()
    {
        yield return new WaitForSeconds(2f);
        comingSoonTxt.SetActive(false);
        canAppearCCT = true;
    }

    // ContinueRewardButton

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
}
