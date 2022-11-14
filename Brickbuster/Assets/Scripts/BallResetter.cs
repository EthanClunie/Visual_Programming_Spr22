using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallResetter : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        Game.Instance.LoseBall();
    }
}
