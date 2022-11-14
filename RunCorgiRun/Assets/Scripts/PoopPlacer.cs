using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    public GameObject PoopPrefab;

    public void Place(Vector3 position)
    {
        Instantiate(PoopPrefab, position, Quaternion.identity);
    }
}
