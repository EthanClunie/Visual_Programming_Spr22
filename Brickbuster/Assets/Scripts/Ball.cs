using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : DeathEffectObject
{
    private Rigidbody physics;

    private bool isInPlay = false;
    private float startSpeed = 300;
    private Transform paddleParent;

    private void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>();
        paddleParent = transform.parent;
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        isInPlay = false;
        physics.isKinematic = true;
        transform.parent = paddleParent;
        transform.position = new Vector3(0f, 0.5f, 0f);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (IsOkToLaunch())
        {
            Launch();
        }
    }

    private void Launch()
    {
        isInPlay = true;
        transform.parent = null;
        physics.isKinematic = false;
        physics.AddForce(new Vector3(startSpeed, startSpeed, 0f));
    }

    private bool IsOkToLaunch()
    {
        if (!isInPlay && Input.GetButtonDown("Fire1"))
        {
            return true;
        }
        return false;
    }
}
