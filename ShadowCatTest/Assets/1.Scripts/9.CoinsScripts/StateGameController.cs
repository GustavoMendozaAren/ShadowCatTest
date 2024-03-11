using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameController : MonoBehaviour
{
    public static int coinsTotal;

    public static int weaponPower;
    public static int lifeValue;
    public static int jumpValue;

    public static float bulletPower = 1f;

    // ***** New UI Store *****

    // Actual Power

    public static float revolverPower = 1f;

    // Barras

    public static int barrasPowerIndex = -1;

    // Text of power

    public static int currentPowerText = 10;
    public static int nextPowerText = 15;

    // Key to Clue Animation

    public static bool pista1 = false;

    // Levels Key To Unlock

    public static bool level2Key = false;

    // Transform to cat

    public static bool isCat = false;

    // TimeScales

    public static float playerTime = 1f;
    public static float enemiesTime = 1f;
    public static float globalTime = 1f;
}
