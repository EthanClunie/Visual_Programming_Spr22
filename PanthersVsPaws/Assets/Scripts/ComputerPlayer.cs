using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour
{
    public TicTacToeGame TicTacToeGame;
    public GameMode GameMode;
    public Slots Slots;
    public TickTackToeResolver TickTackToeResolver;

    public void PlayComputerTurnAfterPause()
    {
        if (GameMode.GetOpponentType() == OpponentType.EasyCPU)
        {
            PlayEasyComputerMove();
        }
        else if (GameMode.GetOpponentType() == OpponentType.HardCPU)
        {
            PlayHardComputerMove();
        }
    }

    private void PlayHardComputerMove()
    {
        bool hasWon = TryToWin();
        if (hasWon)
            return;

        bool hasBlocked = TryToBlock();
        if (hasBlocked)
            return;

        PlayRandomMove();
    }

    private bool TryToWin()
    {
        return TryToPlayBestMove(TicTacToeGame.GetCurrentMarkerType());
    }

    private bool TryToBlock()
    {
        return TryToPlayBestMove(TicTacToeGame.GetFirstPlayerMarkerType());
    }

    private bool TryToPlayBestMove(MarkerType markerType)
    {
        int bestSlotIndex = TickTackToeResolver.FindBestSlotIndexForPlayer(Slots.GetSlotOccupants(), markerType);
        if (bestSlotIndex != -1)
        {
            TicTacToeGame.PlaceMarkerInSlot(Slots.GetSlots(bestSlotIndex));
            return true;
        }
        return false;
    }

    private void PlayEasyComputerMove()
    {
        PlayRandomMove();
    }

    private void PlayRandomMove()
    {
        Slot slot = Slots.RandomFreeSlot();

        TicTacToeGame.PlaceMarkerInSlot(slot);
    }
}
