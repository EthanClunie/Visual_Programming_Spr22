using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public Readouts Readouts;
    public Paddle Paddle;
    public Ball Ball;

    private Levels Levels;
    private int ballsRemaining;
    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        Levels = gameObject.GetComponent<Levels>();
        
    }

    private void Start()
    {
        Reset();
    }

    public void LoseBall()
    {
        Sounds.Instance.PlayLoseLifeSound();
        DisableGameplay();
        Ball.CreateDeathEffect();
        UpdateNumBalls(ballsRemaining - 1);
        CheckForGameOver();
    }

    public void DisableGameplay()
    {
        Paddle.Disable();
        Ball.Disable();
    }

    public void BrickBreak()
    {
        UpdateScore(score + 10);
        CheckIfWon();
    }

    private void Reset()
    {
        Sounds.Instance.PlayStartSound();
        UpdateNumBalls(3);
        UpdateScore(0);
        Readouts.Reset(ballsRemaining);
    }

    private void CheckForGameOver()
    {
        if (ballsRemaining == 0)
        {
            LoseGame();
        }
        else
        {
            ResetAfterBallLoss();
        }
    }

    private void CheckIfWon()
    {
        if (CountBricks() == 0)
        {
            DisableGameplay();
            Levels.GoToNextLevel();
            if (Levels.IsGameOver())
            {
                WinGame();
            }
            else
            {
                ResetAfterBallLoss();
            }
        }
    }

    private void WinGame()
    {
        Readouts.ShowWinResult();
    }

    private void LoseGame()
    {
        Sounds.Instance.PlayGameOverSound();
        Readouts.ShowLoseResult();
    }

    private void ResetAfterBallLoss()
    {
        Paddle.Reset();
        Ball.Reset();
    }

    private int CountBricks()
    {
        return GameObject.FindGameObjectsWithTag("Brick").Length - 1;
    }

    private void UpdateNumBalls(int numBalls)
    {
        ballsRemaining = numBalls;
        Readouts.ShowBallsRemaining(ballsRemaining);
    }

    private void UpdateScore(int newScore)
    {
        score = newScore;
        Readouts.ShowScore(score);
    }
}
