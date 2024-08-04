using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private TMP_Text coinTextScore;

    private BtwnScenes btwnScenes;
    void Start()
    {
        coinTextScore = GameObject.Find("TextCoins").GetComponent<TMP_Text>();
        btwnScenes = FindObjectOfType<BtwnScenes>();

        if (StateGameController.sceneNo == 0)
            coinTextScore.text = StateGameController.levelTut.ToString();
        if (StateGameController.sceneNo == 1)
            coinTextScore.text = StateGameController.level1Coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Coin"))
        {
            target.gameObject.SetActive(false);

            if (StateGameController.levelTut < 1)
            {
                StateGameController.levelTut++;
                StateGameController.coinsTotal = StateGameController.levelTut;
            }

            coinTextScore.text = StateGameController.levelTut.ToString();
        }

        if (target.CompareTag("Coin1"))
        {
            target.gameObject.SetActive(false);

            if (StateGameController.level1Coins < 14)
            {
                StateGameController.level1Coins++;
                StateGameController.coinsTotal = StateGameController.level1Coins;
            }

            //Converse from int to string
            coinTextScore.text = StateGameController.level1Coins.ToString();
        }
    }


}
