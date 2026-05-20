using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreEqp2Cat : MonoBehaviour
{
    [Header ("TEXTOS")]
    [SerializeField] private TMP_Text currentPowTxt;
    [SerializeField] private TMP_Text nextPowtxt;
    [SerializeField] private TMP_Text currentAmountTxt;
    [SerializeField] private TMP_Text nextAmountTxt;

    [Header("PANELES")]
    [SerializeField] private GameObject eqp2CatSmallImg;
    [SerializeField] private GameObject eqp2CatBigImg;
    [SerializeField] private GameObject panel1Cat;
    [SerializeField] private GameObject panel2Incognito;
    [SerializeField] private GameObject panel3Incognito;

    [Header("BOTONES UPGRADE")]
    [SerializeField] private GameObject upgradeButtonSlow;
    [SerializeField] private GameObject upgradeButtonJump;

    [SerializeField] private GameObject[] barrasSlow;
    [SerializeField] private GameObject[] barrasJump;

    [SerializeField] private GameObject needCoinsPanel;

    private TMP_Text coinsText;
    private int currentSlowCount = 4;
    private int nextSlowCount = 6;
    private int currentJumpCount = 6;
    private int nextJumpCount = 8;

    private void Start()
    {
        coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
        coinsText.text = StateGameController.coinsTotal.ToString();

        currentPowTxt.text = StateGameController.currentSlowText + " s";
        nextPowtxt.text = StateGameController.nextSlowText + " s";

        //currentAmountTxt.text = StateGameController.currentAmountTxt.ToString();
        //nextAmountTxt.text = StateGameController.nextAmountTxt.ToString();

        BarrasSlowIndexActive();
        BarrasJumpIndexActive();
    }

    public void Eqp2RevSmallBttnDeact()
    {
        eqp2CatSmallImg.SetActive(false);
        eqp2CatBigImg.SetActive(true);
    }

    public void Eqp2RevBigBttnDeact()
    {
        eqp2CatSmallImg.SetActive(true);
        eqp2CatBigImg.SetActive(false);
    }

    public void Panel1BttnActive()
    {
        panel1Cat.SetActive(true);
        panel2Incognito.SetActive(false);
        panel3Incognito.SetActive(false);
    }

    public void Panel2BttnActive()
    {
        panel1Cat.SetActive(false);
        panel2Incognito.SetActive(true);
        panel3Incognito.SetActive(false);
    }

    public void Panel3BttnActive()
    {
        panel1Cat.SetActive(false);
        panel2Incognito.SetActive(false);
        panel3Incognito.SetActive(true);
    }

    public void UpgradeEqp1GatoSlowBttn()
    {
        if (StateGameController.coinsTotal >= 10)
        {

            if (StateGameController.barrasSlowIndex >= 3)
            {
                StateGameController.barrasSlowIndex = 3;
            }
            else
            {
                StateGameController.barrasSlowIndex++;
                BarrasSlowIndexActive();

                StateGameController.slowdownTime += 2;

                StateGameController.coinsTotal -= 10;
                coinsText.text = StateGameController.coinsTotal.ToString();

                // CurrentDamageTextNumber
                currentSlowCount += 2;
                currentPowTxt.text = currentSlowCount + " s";

                // NextDamageTextnumber
                if (nextSlowCount < 10)
                    nextSlowCount += 2;

                nextPowtxt.text = nextSlowCount + " s";
            }
        }
        else
        {
            needCoinsPanel.SetActive(true);
        }

    }

    public void UpgradeEqp1AmountBttn()
    {
        if (StateGameController.coinsTotal >= 10)
        {

            if (StateGameController.barrasJumpIndex >= 3)
            {
                StateGameController.barrasJumpIndex = 3;
            }
            else
            {
                StateGameController.barrasJumpIndex++;
                BarrasJumpIndexActive();

                StateGameController.jumpPower += 0.1f;

                StateGameController.coinsTotal -= 10;
                coinsText.text = StateGameController.coinsTotal.ToString();

                // CurrentAmountTextNumber
                currentJumpCount += 2;
                currentAmountTxt.text = currentJumpCount.ToString();

                // NextAmountTextnumber
                nextJumpCount += 2;
                nextAmountTxt.text = nextJumpCount.ToString();
            }
        }
        else
        {
            needCoinsPanel.SetActive(true);
        }

    }

    public void BarrasSlowIndexActive()
    {
        if (StateGameController.barrasSlowIndex == 0)
        {
            barrasSlow[0].SetActive(true);
        }
        else if (StateGameController.barrasSlowIndex == 1)
        {
            barrasSlow[0].SetActive(true);
            barrasSlow[1].SetActive(true);
        }
        else if (StateGameController.barrasSlowIndex == 2)
        {
            barrasSlow[0].SetActive(true);
            barrasSlow[1].SetActive(true);
            barrasSlow[2].SetActive(true);
        }

        if (StateGameController.barrasSlowIndex == 2)
        {
            upgradeButtonSlow.SetActive(false);
        }
    }

    public void BarrasJumpIndexActive()
    {
        if (StateGameController.barrasJumpIndex == 0)
        {
            barrasJump[0].SetActive(true);
        }
        else if (StateGameController.barrasJumpIndex == 1)
        {
            barrasJump[0].SetActive(true);
            barrasJump[1].SetActive(true);
        }
        else if (StateGameController.barrasJumpIndex == 2)
        {
            barrasJump[0].SetActive(true);
            barrasJump[1].SetActive(true);
            barrasJump[2].SetActive(true);
        }

        if (StateGameController.barrasJumpIndex == 2)
        {
            upgradeButtonJump.SetActive(false);
        }
    }
}
