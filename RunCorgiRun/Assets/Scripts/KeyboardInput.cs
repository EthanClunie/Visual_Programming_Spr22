using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    public PoopPlacer PoopPlacer;

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))               // if W
        {
            Corgi.MoveManually(new Vector2(0, 1));
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))               // if A
        {
            Corgi.MoveManually(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))               // if S
        {
            Corgi.MoveManually(new Vector2(0, -1));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))               // if D
        {
            Corgi.MoveManually(new Vector2(1, 0));
        }

        // Abilities
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PoopPlacer.Place(Corgi.transform.position);
        }

    }


}
