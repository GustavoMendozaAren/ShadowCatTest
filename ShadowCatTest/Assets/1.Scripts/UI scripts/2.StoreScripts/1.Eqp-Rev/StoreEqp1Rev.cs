using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreEqp1Rev : MonoBehaviour
{
    private TMP_Text coinsText;
    public TMP_Text currentPowTxt, nextPowtxt;
    public TMP_Text currentAmountTxt, nextAmountTxt;

    public GameObject eqp1RevSmallImg, eqp1RevBigImg;
    public GameObject panel1Rev, panel2DoubRev, panel3Incog;

    public GameObject upgradeButtonPower, upgradeButtonAmount;

    public GameObject[] barrasPower;
    public GameObject[] barrasAmount;
    public GameObject needCoinsPanel;

    private void Start()
    {
        coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
        coinsText.text = StateGameController.coinsTotal.ToString();

        currentPowTxt.text = StateGameController.currentDamageText.ToString();
        nextPowtxt.text = StateGameController.nextPowerText.ToString();

        currentAmountTxt.text = StateGameController.currentAmountTxt.ToString();
        nextAmountTxt.text = StateGameController.nextAmountTxt.ToString();

        BarrasDamageIndexActive();
        BarrasAmountIndexActive();
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
                BarrasDamageIndexActive();

                StateGameController.revolverPower += 0.5f;
                
                StateGameController.coinsTotal -= 10;
                coinsText.text = StateGameController.coinsTotal.ToString();

                // CurrentDamageTextNumber
                StateGameController.currentDamageText += 5;
                currentPowTxt.text = StateGameController.currentDamageText.ToString();

                // NextDamageTextnumber
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

    public void UpgradeEqp1AmountBttn()
    {
        if (StateGameController.coinsTotal >= 10)
        {

            if (StateGameController.barrasAmountIndex >= 3)
            {
                StateGameController.barrasAmountIndex = 3;
            }
            else
            {
                StateGameController.barrasAmountIndex++;
                BarrasAmountIndexActive();

                StateGameController.bulletsInGame += 2;

                StateGameController.coinsTotal -= 10;
                coinsText.text = StateGameController.coinsTotal.ToString();

                // CurrentAmountTextNumber
                StateGameController.currentAmountTxt += 2;
                currentAmountTxt.text = StateGameController.currentAmountTxt.ToString();

                // NextAmountTextnumber
                StateGameController.nextAmountTxt += 2;
                nextAmountTxt.text = StateGameController.nextAmountTxt.ToString();
            }
        }
        else
        {
            needCoinsPanel.SetActive(true);
            //ToClosePanelSeeCurrencyScript
        }

    }

    public void BarrasDamageIndexActive()
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
        }
    }

    public void BarrasAmountIndexActive()
    {
        if (StateGameController.barrasAmountIndex == 0)
        {
            barrasAmount[0].SetActive(true);
        }
        else if (StateGameController.barrasAmountIndex == 1)
        {
            barrasAmount[0].SetActive(true);
            barrasAmount[1].SetActive(true);
        }
        else if (StateGameController.barrasAmountIndex == 2)
        {
            barrasAmount[0].SetActive(true);
            barrasAmount[1].SetActive(true);
            barrasAmount[2].SetActive(true);
        }

        if (StateGameController.barrasAmountIndex == 2)
        {
            upgradeButtonAmount.SetActive(false);
        }
    }
}
