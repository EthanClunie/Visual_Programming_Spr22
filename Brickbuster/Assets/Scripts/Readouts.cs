using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Readouts : MonoBehaviour
{
    public Text ScoreText;
    public Text BallsRemainingText;
    public Text LevelText;
    public Text GameResultText;

    public void Reset(int initNumberOfBalls)
    {
        ShowScore(0);
        ShowLevel(1);
        ShowBallsRemaining(initNumberOfBalls);
        HideWinResults();
    }

    public void ShowScore(int score)
    {
        if (score < 0)
            score = 0;
        ScoreText.text = "Score: " + score;
    }

    public void ShowBallsRemaining(int ballsRemaining)
    {
        if (ballsRemaining < 0)
            ballsRemaining = 0;
        BallsRemainingText.text = "Balls Remaining: " + ballsRemaining;
    }

    public void ShowLevel(int level)
    {
        if (level < 1)
            level = 1;
        LevelText.text = "Level: " + level;
    }

    public void ShowWinResult()
    {
        GameResultText.text = "WIN";
    }

    public void ShowLoseResult()
    {
        GameResultText.text = "LOSE";
    }

    public void HideWinResults()
    {
        GameResultText.text = "";
    }
}
