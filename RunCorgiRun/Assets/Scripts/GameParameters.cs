using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameParameters
{
    // Movement Params
    public static float CorgiMoveAmount = 0.02f;
    public static int CorgiMinNumRandomSteps = 2;
    public static int CorgiMaxNumRandomSteps = 5;

    // Corgi Drunkenness Duration
    public static int CorgiTimeUntilSoberedUp = 3;

    // Poop destruction
    public static int PoopSecondsOnScreen = 3;

    // Beer creation and destruction
    public static int BeerMinTimeForCreation = 1;
    public static int BeerMaxTimeForCreation = 3;
    public static int BeerSecondsOnScreen = 3;

    // Bone creation and destruction
    public static int BoneMinTimeForCreation = 1;
    public static int BoneMaxTimeForCreation = 3;
    public static int BoneSecondsOnScreen = 3;

    // Pill creation and destruction
    public static int PillMinTimeForCreation = 3;
    public static int PillMaxTimeForCreation = 5;
    public static int PillSecondsOnScreen = 3;

    // Moonshine creation and destruction
    public static int MoonshineMinTimeForCreation = 3;
    public static int MoonshineMaxTimeForCreation = 5;
    public static int MoonshineSecondsOnScreen = 3;

    // Point amounts for different items
    public static int BonePoints = 1;
}
