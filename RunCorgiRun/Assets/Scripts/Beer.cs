using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : TimedObject
{
    // Start is called before the first frame update
    public override void Start()
    {
        secondsOnScreen = GameParameters.BeerSecondsOnScreen;
        base.Start();
    }

}
