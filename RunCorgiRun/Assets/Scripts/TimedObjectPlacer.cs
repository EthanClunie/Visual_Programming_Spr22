using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject ObjectPrefab;

    private int secondsUntilNextCreation;
    private bool isWaitingToCreate = false;

    protected int minTimeToCreation = 1;
    protected int maxTimeToCreation = 3;

    // Update is called once per frame
    void Update()
    {
        if (!isWaitingToCreate)
        {
            // Pick a random countdown time
            secondsUntilNextCreation = Random.Range(minTimeToCreation, maxTimeToCreation);
            isWaitingToCreate = true;

            // Start countdown
            StartCoroutine(CountdownUntilCreation());
        }

    }

    IEnumerator CountdownUntilCreation()
    {
        yield return new WaitForSeconds(secondsUntilNextCreation);
        Place();
        isWaitingToCreate = false;
    }

    protected virtual void Place()
    {
        Instantiate(ObjectPrefab, ScreenPositionTools.RandomWorldLocation(), Quaternion.identity);
    }
}
