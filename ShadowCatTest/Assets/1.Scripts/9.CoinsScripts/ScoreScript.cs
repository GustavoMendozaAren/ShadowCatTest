using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private TMP_Text coinTextScore;
    void Start()
    {
        coinTextScore = GameObject.Find("TextCoins").GetComponent<TMP_Text>();

        if (StateGameController.sceneNo == 1)
            coinTextScore.text = StateGameController.level1Coins.ToString();
        if (StateGameController.sceneNo == 2)
            coinTextScore.text = StateGameController.level2Coins.ToString();
        if (StateGameController.sceneNo == 3)
            coinTextScore.text = StateGameController.level3Coins.ToString();
        if (StateGameController.sceneNo == 4)
            coinTextScore.text = StateGameController.level4Coins.ToString();
        if (StateGameController.sceneNo == 5)
            coinTextScore.text = StateGameController.level5Coins.ToString();
        if (StateGameController.sceneNo == 6)
            coinTextScore.text = StateGameController.level6Coins.ToString();
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
                if (StateGameController.level2Coins < 10)
                {
                    StateGameController.level2Coins++;
                    StateGameController.coinsTotal++;
                }

                coinTextScore.text = StateGameController.level2Coins.ToString();
            }

            if (StateGameController.sceneNo == 3)
            {
                if (StateGameController.level3Coins < 10)
                {
                    StateGameController.level3Coins++;
                    StateGameController.coinsTotal++;
                }

                coinTextScore.text = StateGameController.level3Coins.ToString();
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

            if (StateGameController.sceneNo == 5)
            {
                if (StateGameController.level5Coins < 10)
                {
                    StateGameController.level5Coins++;
                    StateGameController.coinsTotal++;
                }

                coinTextScore.text = StateGameController.level5Coins.ToString();
            }

            if (StateGameController.sceneNo == 6)
            {
                if (StateGameController.level6Coins < 10)
                {
                    StateGameController.level6Coins++;
                    StateGameController.coinsTotal++;
                }

                coinTextScore.text = StateGameController.level6Coins.ToString();
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
