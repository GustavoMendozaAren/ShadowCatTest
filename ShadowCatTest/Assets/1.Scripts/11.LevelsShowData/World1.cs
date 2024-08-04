using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class World1 : MonoBehaviour
{
    public TMP_Text totalCoins1S, totalCoins1B;
    private void Start()
    {
        totalCoins1S.text = "Coins:" + StateGameController.level1Coins + "/14";
        totalCoins1B.text = "Coins:" + StateGameController.level1Coins + "/14";
    }
}
