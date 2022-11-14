using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGame : MonoBehaviour
{
    public Slots Slots;
    public TickTackToeResolver TickTackToeResolver;
    public TurnDisplay TurnDisplay;
    public WinnerDisplay WinnerDisplay;
    public GameMode GameMode;
    public Sounds Sounds;
    public ComputerPlayer CPU;

    private MarkerType currentMarkerType;
    private MarkerType firstPlayerMarkerType;
    private int numberOfTurnsPlayed;
    private bool isWaitingForCpuToPlay;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void OnSlotClicked(Slot slot)
    {
        if (!isWaitingForCpuToPlay)
            PlaceMarkerInSlot(slot);
    }

    public void OnResetButtonClicked()
    {
        Reset();
        Sounds.PlayResetButtonSound();
    }

    public void Reset()
    {
        // players, displays, number of turns played, slots, sounds
        ResetPlayers();
        ResetDisplays();   
        numberOfTurnsPlayed = 0;
        ResetSlots();
        ResetSounds();
    }

    public void ChangeOpponent()
    {
        Reset();
    }

    public MarkerType GetCurrentMarkerType()
    {
        return currentMarkerType;
    }

    public MarkerType GetFirstPlayerMarkerType()
    {
        return firstPlayerMarkerType;
    }

    public void PlaceMarkerInSlot(Slot slot)
    {
        if (GameNotOver())
        {
            UpdateSlotImage(slot);

            Sounds.PlayRandomMarkerSound();

            CheckForWinner();

            EndTurn();
        }

    }

    private void ResetSlots()
    {
        Slots.Reset();
    }

    private void ResetSounds()
    {
        Sounds.Reset();
    }

    private void ResetPlayers()
    {
        TickTackToeResolver.Reset();
        RandomizePlayer();
        firstPlayerMarkerType = currentMarkerType;
        isWaitingForCpuToPlay = false;
    }

    private void ResetDisplays()
    {
        TurnDisplay.Reset(currentMarkerType);
        WinnerDisplay.Reset();
    }

    private bool GameNotOver()
    {
        return TickTackToeResolver.NoWinner();
    }

    private void CheckForWinner()
    {
        numberOfTurnsPlayed++;
        if (numberOfTurnsPlayed < 5)
            return;

        TickTackToeResolver.CheckForEndOfGame(Slots.GetSlotOccupants());
    }

    private void EndTurn()
    {
        if (GameNotOver())
        {
            ChangePlayer();
        }
        else
        {
            ShowWinner();
        }
    }

    private void ShowWinner()
    {
        PlayEndOfGameSound();
        WinnerDisplay.Show(TickTackToeResolver.Winner());
    }

    private void PlayEndOfGameSound()
    {
        if (TickTackToeResolver.Winner() == MarkerType.Tie)
        {
            Sounds.PlayTieGameSound();
        }
        else
        {
            Sounds.PlayGameOverSound();
        }       
    }

    private void ChangePlayer()
    {
        if (currentMarkerType == MarkerType.Paw)
            currentMarkerType = MarkerType.Panther;
        else
            currentMarkerType = MarkerType.Paw;

        TurnDisplay.Show(currentMarkerType);

        ShouldComputerPlay();
    }

    private void ShouldComputerPlay()
    {
        if (currentMarkerType == firstPlayerMarkerType)     // Checks if it isHumanTurn
            return;

        if (IsPlayingComputerOpponent())
            PlayComputerTurn();

    }

    private bool IsPlayingComputerOpponent()
    {
        return GameMode.GetOpponentType() != OpponentType.Human;
    }

    private void PlayComputerTurn()
    {
        StartCoroutine(PauseForComputerPlayer());
    }

    IEnumerator PauseForComputerPlayer()
    {
        isWaitingForCpuToPlay = true;
        float secondsToWait = Random.Range(0.5f, 1f);
        yield return new WaitForSeconds(secondsToWait);
        isWaitingForCpuToPlay = false;
        CPU.PlayComputerTurnAfterPause();
    }

    private void UpdateSlotImage(Slot slot)
    {
        Slots.UpdateSlot(slot, currentMarkerType);
    }

    private void RandomizePlayer()
    {
        int randNumber = Random.Range(1, 3);
        if (randNumber == 1)
            currentMarkerType = MarkerType.Panther;
        else
            currentMarkerType = MarkerType.Paw;
    }
}
