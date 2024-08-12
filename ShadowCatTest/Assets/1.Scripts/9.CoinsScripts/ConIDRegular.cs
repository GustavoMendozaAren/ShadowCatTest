using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConIDRegular : MonoBehaviour
{
    private int coinIDregular;

    private void Start()
    {
        coinIDregular = StateGameController.sceneNo;
    }
}
