using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public TicTacToeGame Game;
    public Sounds Sounds;

    private OpponentType currentOpponentType;

    void Start()
    {
        currentOpponentType = OpponentType.Human;
    }

    public void OnClick(int buttonNumber)
    {
        Sounds.PlayGameModeSound();
        OpponentType opponentType = SetOpponentType(buttonNumber);
        ChangeOpponentType(opponentType);
    }

    public OpponentType GetOpponentType()
    {
        return currentOpponentType;
    }

    private OpponentType SetOpponentType(int buttonNumber)
    {
        if (buttonNumber == 1)              // Easy CPU
        {   
            return OpponentType.EasyCPU;
        }
        else if (buttonNumber == 2)         // Human
        {
            return OpponentType.Human;
        }
        return OpponentType.HardCPU;
    }

    private void ChangeOpponentType(OpponentType opponentType)
    {
        if (opponentType == currentOpponentType)
            return;

        currentOpponentType = opponentType;
        Game.ChangeOpponent();
    }
}
