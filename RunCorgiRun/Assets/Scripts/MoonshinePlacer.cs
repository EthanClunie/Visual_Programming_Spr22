using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    void Start()
    {
        minTimeToCreation = GameParameters.MoonshineMinTimeForCreation;
        maxTimeToCreation = GameParameters.MoonshineMaxTimeForCreation;
    }

    protected override void Place()
    {
        Instantiate(ObjectPrefab, ScreenPositionTools.RandomTopOfScreenWorldLocation(), Quaternion.identity);
    }
}
