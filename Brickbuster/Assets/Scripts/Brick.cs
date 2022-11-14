using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : DeathEffectObject
{
    public GameObject FloatingScorePrefab;

    public void OnCollisionEnter(Collision collision)
    {
        CreateDeathEffect();
        Instantiate(FloatingScorePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Game.Instance.BrickBreak();
    }

}
