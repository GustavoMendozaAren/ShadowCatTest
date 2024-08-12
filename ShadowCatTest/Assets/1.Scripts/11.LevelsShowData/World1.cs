using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class World1 : MonoBehaviour
{
    public TMP_Text[] totalCoinsS;
    public TMP_Text[] totalCoinsB;
    private void Start()
    {
        totalCoinsS[0].text = "Coins:" + StateGameController.level2Coins + "/14";
        totalCoinsB[0].text = "Coins:" + StateGameController.level2Coins + "/14";

        totalCoinsS[1].text = "Coins:" + StateGameController.level3Coins + "/10";
        totalCoinsB[1].text = "Coins:" + StateGameController.level3Coins + "/10";

        totalCoinsS[2].text = "Coins:" + StateGameController.level4Coins + "/10";
        totalCoinsB[2].text = "Coins:" + StateGameController.level4Coins + "/10";

        totalCoinsS[3].text = "Coins:" + StateGameController.level5Coins + "/10";
        totalCoinsB[3].text = "Coins:" + StateGameController.level5Coins + "/10";

        totalCoinsS[4].text = "Coins:" + StateGameController.level6Coins + "/10";
        totalCoinsB[4].text = "Coins:" + StateGameController.level6Coins + "/10";
    }
}
