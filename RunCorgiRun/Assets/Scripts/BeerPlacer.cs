using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPlacer : TimedObjectPlacer
{
    void Start()
    {
        minTimeToCreation = GameParameters.BeerMinTimeForCreation;
        maxTimeToCreation = GameParameters.BeerMaxTimeForCreation;
    }

}
