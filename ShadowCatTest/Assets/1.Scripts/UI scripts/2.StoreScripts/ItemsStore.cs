using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsStore : MonoBehaviour
{

    public Slider[] slider;

    public Animator[] neeeCoinsAnim;

    private TMP_Text coinsText;

    private void Start()
    {
        slider[0].value = StateGameController.weaponPower;
        coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
        coinsText.text = StateGameController.coinsTotal.ToString();
    }

    /*public void MinusWeaponButton()
    {

        if (StateGameController.weaponPower <= 0)
        {
            StateGameController.weaponPower = 0;
        }
        else
        {
            StateGameController.weaponPower--;
            StateGameController.coinsTotal += 10;
            coinsText.text = "Coins: " + StateGameController.coinsTotal;
        }
        slider[0].value = StateGameController.weaponPower;
    }*/

    public void PlusWeaponButton()
    {
        if(StateGameController.coinsTotal >= 10)
        {
            if (StateGameController.weaponPower >= 4)
            {
                StateGameController.weaponPower = 4;
            }
            else
            {
                StateGameController.weaponPower++;
                StateGameController.bulletPower += 0.5f;
                StateGameController.coinsTotal -= 10;
                coinsText.text = StateGameController.coinsTotal.ToString();
            }
            slider[0].value = StateGameController.weaponPower;
        }
        else
        {
            neeeCoinsAnim[0].SetTrigger("NeedCoins");
        }  
    }

    public void PlusLifeButton()
    {
        if (StateGameController.coinsTotal >= 20)
        {
            if (StateGameController.lifeValue >= 4)
            {
                StateGameController.lifeValue = 4;
            }
            else
            {
                StateGameController.lifeValue++;
                StateGameController.coinsTotal -= 20;
                coinsText.text = StateGameController.coinsTotal.ToString();
            }
            slider[1].value = StateGameController.lifeValue;
        }
        else
        {
            neeeCoinsAnim[1].SetTrigger("Need20Coins");
        }
    }

    public void PlusJumpButton()
    {
        if (StateGameController.coinsTotal >= 30)
        {
            if (StateGameController.jumpValue >= 4)
            {
                StateGameController.jumpValue = 4;
            }
            else
            {
                StateGameController.jumpValue++;
                StateGameController.coinsTotal -= 30;
                coinsText.text = StateGameController.coinsTotal.ToString();
            }
            slider[2].value = StateGameController.jumpValue;
        }
        else
        {
            neeeCoinsAnim[2].SetTrigger("Need30Coins");
        }
    }
}
