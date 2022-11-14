using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    protected int secondsOnScreen = 3;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Start countdown to "death"
        StartCoroutine(CountdownUntilDeath());
    }

    IEnumerator CountdownUntilDeath()
    {
        yield return new WaitForSeconds(secondsOnScreen);
        Destroy(this.gameObject);
    }
}
