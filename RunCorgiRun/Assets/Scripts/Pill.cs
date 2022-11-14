using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : TimedObject
{
    // Start is called before the first frame update
    public override void Start()
    {
        secondsOnScreen = GameParameters.PillSecondsOnScreen;
        base.Start();
    }
}
