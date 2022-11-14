using UnityEngine;

public static class ScreenPositionTools
{
    public static Vector3 RandomScreenLocation()
    {
        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);

        return new Vector3(randomX, randomY, 10);
    }

    public static Vector3 RandomWorldLocation()
    {
        Vector3 randomScreenLocation = RandomScreenLocation();
        return Camera.main.ScreenToWorldPoint(randomScreenLocation);
    }

    public static Vector3 RandomTopOfScreenLocation()
    {
        float randomX = Random.Range(0, Screen.width);
        return new Vector3(randomX, Screen.height, 10);
    }

    public static Vector3 RandomTopOfScreenWorldLocation()
    {
        Vector3 randomTopOfScreenLocation = RandomTopOfScreenLocation();
        return Camera.main.ScreenToWorldPoint(randomTopOfScreenLocation);
    }
}
