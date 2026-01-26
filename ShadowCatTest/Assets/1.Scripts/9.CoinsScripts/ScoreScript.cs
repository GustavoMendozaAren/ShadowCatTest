using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private TMP_Text coinTextScore;

    private void Awake()
    {
        coinTextScore = GameObject.Find("TextCoins").GetComponent<TMP_Text>();
    }
    void Start()
    {
        if (StateGameController.sceneNo == 1)
            coinTextScore.text = StateGameController.level1Coins.ToString();
        if (StateGameController.sceneNo == 2)
            coinTextScore.text = StateGameController.level2Coins.ToString();
        if (StateGameController.sceneNo == 3)
            coinTextScore.text = StateGameController.level3Coins.ToString();
        if (StateGameController.sceneNo == 4)
            coinTextScore.text = StateGameController.level4Coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Coin"))
        {
            target.gameObject.SetActive(false);

            if (StateGameController.sceneNo == 1)
            {
                if (StateGameController.level1Coins < 1)
                {
                    StateGameController.level1Coins++;
                    StateGameController.coinsTotal++;
                }

                coinTextScore.text = StateGameController.level1Coins.ToString();
            }

            if (StateGameController.sceneNo == 2)
            {
                if (StateGameController.level2Coins < 46)
                {
                    StateGameController.level2Coins++;
                    StateGameController.coinsTotal++;
                    coinTextScore.text = StateGameController.level2Coins.ToString();
                }
            }

            if (StateGameController.sceneNo == 3)
            {
                if (StateGameController.level3Coins < 10)
                {
                    StateGameController.level3Coins++;
                    StateGameController.coinsTotal++;
                    coinTextScore.text = StateGameController.level3Coins.ToString();
                }
            }

            if (StateGameController.sceneNo == 4)
            {
                if (StateGameController.level4Coins < 10)
                {
                    StateGameController.level4Coins++;
                    StateGameController.coinsTotal++;
                }

                coinTextScore.text = StateGameController.level4Coins.ToString();
            }
        }

        /*
        if (target.CompareTag("Coin1"))
        {
            target.gameObject.SetActive(false);

            if (StateGameController.level2Coins < 14)
            {
                StateGameController.level2Coins++;
                StateGameController.coinsTotal = StateGameController.level2Coins;
            }

            //Converse from int to string
            coinTextScore.text = StateGameController.level1Coins.ToString();
        }
        */
    }


}
