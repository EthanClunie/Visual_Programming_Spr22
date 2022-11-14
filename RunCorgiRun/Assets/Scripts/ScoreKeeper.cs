using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;

    public static void AddToScore(int amountToAdd)
    {
        score += amountToAdd;
    }

    public static int GetScore()
    {
        return score;
    }
}
