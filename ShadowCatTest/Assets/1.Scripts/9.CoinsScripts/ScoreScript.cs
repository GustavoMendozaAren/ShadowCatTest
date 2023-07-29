using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private TMP_Text coinTextScore;
    private int scoreCount;

    private BtwnScenes btwnScenes;
    void Start()
    {
        coinTextScore = GameObject.Find("TextCoins").GetComponent<TMP_Text>();
        btwnScenes = FindObjectOfType<BtwnScenes>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Coin"))
        {
            //Debug.Log("Coin");
            target.gameObject.SetActive(false);
            scoreCount++;

            coinTextScore.text = scoreCount.ToString();

            StateGameController.coinsTotal++;
            //btwnScenes.CoinsCollected++;
        }
    }


}
