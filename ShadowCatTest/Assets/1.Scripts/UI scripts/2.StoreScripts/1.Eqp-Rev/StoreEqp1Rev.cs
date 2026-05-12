using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreEqp1Rev : MonoBehaviour
{
    [SerializeField] private TMP_Text currentPowTxt, nextPowtxt;
    [SerializeField] private TMP_Text currentAmountTxt, nextAmountTxt;
    [SerializeField] private TMP_Text currentEscopetaDamageTxt, nextEscopetaDamageTxt;
    [SerializeField] private TMP_Text currentEscopetaAuraTxt, nextEscopetaAuraTxt;

    [SerializeField] private GameObject eqp1RevSmallImg, eqp1RevBigImg;
    [SerializeField] private GameObject panel1Rev, panel2DoubRev, panel3Incog;
    [SerializeField] private GameObject panelBlackEscopeta;
    [SerializeField] private GameObject instructionsPanel;

    [SerializeField] private GameObject upgradeButtonPower, upgradeButtonAmount, upgradeButtonEscopetaDamage, upgradeButtonEscopetaAura;

    [SerializeField] private GameObject[] barrasPower;
    [SerializeField] private GameObject[] barrasAmount;
    [SerializeField] private GameObject[] barrasEscopetaDamage;
    [SerializeField] private GameObject[] barrasEscopetaAura;

    [SerializeField] private GameObject needCoinsPanel;

    private TMP_Text coinsText;

    private void Start()
    {
        coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
        coinsText.text = StateGameController.coinsTotal.ToString();

        currentPowTxt.text = StateGameController.currentDamageText.ToString();
        nextPowtxt.text = StateGameController.nextPowerText.ToString();

        currentAmountTxt.text = StateGameController.currentAmountTxt.ToString();
        nextAmountTxt.text = StateGameController.nextAmountTxt.ToString();

        currentEscopetaDamageTxt.text = StateGameController.currentEscopetaDamageTxt.ToString();
        nextEscopetaDamageTxt.text = StateGameController.nextEscopetaDamageTxt.ToString();

        currentEscopetaAuraTxt.text = StateGameController.currentEscopetaAuraTxt.ToString();
        nextEscopetaAuraTxt.text = StateGameController.nextEscopetaAuraTxt.ToString();

        //BarrasDamageIndexActive();
        //BarrasAmountIndexActive();
        ActualizarBarrasImagenes(StateGameController.barrasPowerIndex, barrasPower, upgradeButtonPower);
        ActualizarBarrasImagenes(StateGameController.barrasAmountIndex, barrasAmount, upgradeButtonAmount);
        ActualizarBarrasImagenes(StateGameController.barrasEscopetaDamageIndex, barrasEscopetaDamage, upgradeButtonEscopetaDamage);
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

    public void DesactivarPanelBlackEscopeta()
    {
        if (StateGameController.coinsTotal >= 25)
        {
            StateGameController.isShotgunUnlock = true;
            panelBlackEscopeta.SetActive(false);
            instructionsPanel.SetActive(true);
            StateGameController.coinsTotal -= 25;
            coinsText.text = StateGameController.coinsTotal.ToString();
        }
        else
        {
            needCoinsPanel.SetActive(true);
        }
    }

    public void CloseInstructionsPanel()
    {
        instructionsPanel.SetActive(false);
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
                //BarrasDamageIndexActive();
                ActualizarBarrasImagenes(StateGameController.barrasPowerIndex, barrasPower, upgradeButtonPower);

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
                //BarrasAmountIndexActive();
                ActualizarBarrasImagenes(StateGameController.barrasAmountIndex, barrasAmount, upgradeButtonAmount);

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

    public void UpgradeEqp1EscopetaDamageBttn()
    {
        if (StateGameController.coinsTotal >= 10)
        {

            if (StateGameController.barrasEscopetaDamageIndex >= 3)
            {
                StateGameController.barrasEscopetaDamageIndex = 3;
            }
            else
            {
                StateGameController.barrasEscopetaDamageIndex++;
                //BarrasAmountIndexActive();
                ActualizarBarrasImagenes(StateGameController.barrasEscopetaDamageIndex, barrasEscopetaDamage, upgradeButtonEscopetaDamage);

                StateGameController.EscopetaDamage += 10;

                StateGameController.coinsTotal -= 10;
                coinsText.text = StateGameController.coinsTotal.ToString();

                // CurrentAmountTextNumber
                StateGameController.currentEscopetaDamageTxt += 10;
                currentEscopetaDamageTxt.text = StateGameController.currentEscopetaDamageTxt.ToString();

                // NextAmountTextnumber
                if (StateGameController.barrasEscopetaDamageIndex < 2)
                {
                    StateGameController.nextEscopetaDamageTxt += 10;
                    nextEscopetaDamageTxt.text = StateGameController.nextEscopetaDamageTxt.ToString();
                }
            }
        }
        else
        {
            needCoinsPanel.SetActive(true);
            //ToClosePanelSeeCurrencyScript
        }
    }

    public void UpgradeEqp1EscopetaAuraBttn()
    {
        if (StateGameController.coinsTotal >= 10)
        {

            if (StateGameController.barrasEscopetaAuraIndex >= 3)
            {
                StateGameController.barrasEscopetaAuraIndex = 3;
            }
            else
            {
                StateGameController.barrasEscopetaAuraIndex++;
                //BarrasAmountIndexActive();
                ActualizarBarrasImagenes(StateGameController.barrasEscopetaAuraIndex, barrasEscopetaAura, upgradeButtonEscopetaAura);

                StateGameController.AuraFarming += 3;

                StateGameController.coinsTotal -= 10;
                coinsText.text = StateGameController.coinsTotal.ToString();

                // CurrentAmountTextNumber
                StateGameController.currentEscopetaAuraTxt += 3;
                currentEscopetaAuraTxt.text = StateGameController.currentEscopetaAuraTxt.ToString();

                // NextAmountTextnumber
                if (StateGameController.barrasEscopetaAuraIndex < 2)
                {
                    StateGameController.nextEscopetaAuraTxt += 3;
                    nextEscopetaAuraTxt.text = StateGameController.nextEscopetaAuraTxt.ToString();
                }
            }
        }
        else
        {
            needCoinsPanel.SetActive(true);
            //ToClosePanelSeeCurrencyScript
        }
    }

    private void ActualizarBarrasImagenes(int cantidad, GameObject[] barras, GameObject button)
    {
        if (cantidad == 0)
        {
            barras[0].SetActive(true);
        }
        else if (cantidad == 1)
        {
            barras[0].SetActive(true);
            barras[1].SetActive(true);
        }
        else if (cantidad == 2)
        {
            barras[0].SetActive(true);
            barras[1].SetActive(true);
            barras[2].SetActive(true);
        }

        if (cantidad == 2)
        {
            button.SetActive(false);
        }
    }
}
