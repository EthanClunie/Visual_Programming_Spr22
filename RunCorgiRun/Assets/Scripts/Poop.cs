using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : TimedObject
{
    // Start is called before the first frame update
    public override void Start()
    {
        secondsOnScreen = GameParameters.PoopSecondsOnScreen;
        base.Start();
    }
}
