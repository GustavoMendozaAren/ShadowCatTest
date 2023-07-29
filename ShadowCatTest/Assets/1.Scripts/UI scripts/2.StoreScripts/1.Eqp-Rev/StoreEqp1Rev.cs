using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreEqp1Rev : MonoBehaviour
{
    private TMP_Text coinsText;
    public TMP_Text currentPowTxt, nextPowtxt;

    public GameObject eqp1RevSmallImg, eqp1RevBigImg;
    public GameObject panel1Rev, panel2DoubRev, panel3Incog;

    public GameObject upgradeButtonPower, toMaxTexts;

    public GameObject[] barrasPower;
    public GameObject needCoinsPanel;

    private void Start()
    {
        coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
        coinsText.text = StateGameController.coinsTotal.ToString();

        currentPowTxt.text = StateGameController.currentPowerText.ToString();
        nextPowtxt.text = StateGameController.nextPowerText.ToString();

        BarrasIndexActive();
    }

    public void Eqp1RevSmallBttnDeact()
    {
        eqp1RevSmallImg.SetActive(false);
        eqp1RevBigImg.SetActive(true);
    }

    public void Eqp1RevBigBttnDeact()
    {
        eqp1RevSmallImg.SetActive(true);
        eqp1RevBigImg.SetActive(false);
    }

    public void Panel1BttnActive()
    {
        panel1Rev.SetActive(true);
        panel2DoubRev.SetActive(false);
        panel3Incog.SetActive(false);
    }

    public void Panel2BttnActive()
    {
        panel1Rev.SetActive(false);
        panel2DoubRev.SetActive(true);
        panel3Incog.SetActive(false);
    }

    public void Panel3BttnActive()
    {
        panel1Rev.SetActive(false);
        panel2DoubRev.SetActive(false);
        panel3Incog.SetActive(true);
    }

    public void UpgradeEqp1PowerBttn()
    {
        if(StateGameController.coinsTotal >= 10)
        {
            
            if (StateGameController.barrasPowerIndex >= 3)
            {
                StateGameController.barrasPowerIndex = 3;
            }
            else
            {
                StateGameController.barrasPowerIndex++;
                BarrasIndexActive();

                StateGameController.revolverPower += 0.5f;
                
                StateGameController.coinsTotal -= 10;
                coinsText.text = StateGameController.coinsTotal.ToString();

                // CurrentPoewerTextNumber
                StateGameController.currentPowerText += 5;
                currentPowTxt.text = StateGameController.currentPowerText.ToString();

                // NextPowerTextnumber
                StateGameController.nextPowerText += 5;
                nextPowtxt.text = StateGameController.nextPowerText.ToString();
            }
        }
        else
        {
            needCoinsPanel.SetActive(true);
            //ToClosePanelSeeCurrencyScript
        }
        
    }

    public void BarrasIndexActive()
    {
        if (StateGameController.barrasPowerIndex == 0)
        {
            barrasPower[0].SetActive(true);
        }
        else if (StateGameController.barrasPowerIndex == 1)
        {
            barrasPower[0].SetActive(true);
            barrasPower[1].SetActive(true);
        }
        else if (StateGameController.barrasPowerIndex == 2)
        {
            barrasPower[0].SetActive(true);
            barrasPower[1].SetActive(true);
            barrasPower[2].SetActive(true);
        }

        if (StateGameController.barrasPowerIndex == 2)
        {
            upgradeButtonPower.SetActive(false);
            toMaxTexts.SetActive(false);
        }
    }
}
