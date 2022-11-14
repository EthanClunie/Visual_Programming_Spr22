using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : TimedObject
{
    // Start is called before the first frame update
    public override void Start()
    {
        secondsOnScreen = GameParameters.BoneSecondsOnScreen;
        base.Start();
    }

}
