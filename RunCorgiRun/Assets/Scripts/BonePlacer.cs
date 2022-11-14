using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePlacer : TimedObjectPlacer
{
    void Start()
    {
        minTimeToCreation = GameParameters.BoneMinTimeForCreation;
        maxTimeToCreation = GameParameters.BoneMaxTimeForCreation;
    }

}
