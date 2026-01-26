using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameController : MonoBehaviour
{

    //OLD

    public static int weaponPower;
    public static int lifeValue;
    public static int jumpValue;

    public static float bulletPower = 1f;

    // *************** NEW UI STORE ********************

    // COINS

    public static int coinsTotal = 0;

    // POWER AND BULLETS

    public static float revolverPower = 1f;
    public static int bulletsInGame = 6;

    // SLOW AND JUMP

    public static float slowdownTime = 4f;

    // Barras

    public static int barrasPowerIndex = -1;
    public static int barrasAmountIndex = -1;

    public static int barrasSlowIndex = -1;
    public static int barrasJumpIndex = -1;

    // TEXT OF POWERS AND AMOUNT

    public static int currentDamageText = 10;
    public static int nextPowerText = 15;

    public static int currentAmountTxt = 6;
    public static int nextAmountTxt = 8;

    // TEXT OF SLOW AND JUMP

    public static int currentSlowText = 4;
    public static int nextSlowText = 6;

    // ***************

    // Transform to cat

    public static bool isCat = false;

    // Player Can Die

    public static bool playerCanDie = true;

    // Scene Number

    public static int sceneNo = 0;
    public static bool[] nivelDesbloqueado = new bool[3];
    public static bool[] pistaCandado = new bool[6];

    // TimeScales

    public static float playerTime = 1f;
    public static float enemiesTime = 1f;
    public static float globalTime = 1f;

    // LEVEL 1 COINS

    public static int level1Coins = 0;
    public static int level2Coins = 0;
    public static int level3Coins = 0;
    public static int level4Coins = 0;

    // BRIGHTNESS 

    public static float brightnessScreen = 0.55f;
}
