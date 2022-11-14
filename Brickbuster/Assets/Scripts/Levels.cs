using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public List<GameObject> levelsList;
    public Readouts Readouts;

    private GameObject levelGameObject;
    private int currentLevel = 0;

    void Start()
    {
        levelGameObject = CreateLevel();
        UpdateLevelReadout();
    }

    public void GoToNextLevel()
    {
        currentLevel++;
        if (IsGameOver())
        {
            return;
        }

        LoadNextLevel();
    }

    public bool IsGameOver()
    {
        if (currentLevel == levelsList.Count)
        {
            return true;
        }

        return false;
    }

    private void LoadNextLevel()
    {
        if (levelGameObject != null)
        {
            Destroy(levelGameObject);
        }

        levelGameObject = CreateLevel();
        UpdateLevelReadout();
    }

    private GameObject CreateLevel()
    {
    return Instantiate(levelsList[currentLevel], levelsList[currentLevel].transform.position, Quaternion.identity);
    }

    private void UpdateLevelReadout()
    {
        Readouts.ShowLevel(currentLevel + 1);
    }
}
