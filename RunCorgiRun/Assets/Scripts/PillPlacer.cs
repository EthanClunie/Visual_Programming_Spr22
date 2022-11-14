using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillPlacer : TimedObjectPlacer
{
    void Start()
    {
        minTimeToCreation = GameParameters.PillMinTimeForCreation;
        maxTimeToCreation = GameParameters.PillMaxTimeForCreation;
    }
}
