using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public KeypadBackground Background;

    private Combination combination;
    private List<int> buttonsEntered;

    // Start is called before the first frame update
    void Start()
    {
        combination = new Combination();
        ResetButtonEntries();
    }

    public void RegisterButtonClick(int buttonValue)
    {
        buttonsEntered.Add(buttonValue);
        print(String.Join(", ", buttonsEntered));
    }

    public void TryToUnlock()
    {
        if (IsCorrectCombination())
        {
            Unlock();
        }
        else
        {
            FailToUnlock();
        }

        ResetButtonEntries();
    }

    private bool IsCorrectCombination()
    {
        if (HaveNoButtonsBeenClicked())
        {
            return false;
        }
        if (HaveWrongNumberOfButtonsBeenClicked())
        {
            return false;
        }

        return CheckCombination();
    }

    private bool HaveNoButtonsBeenClicked()
    {
        return (buttonsEntered.Count == 0);
    }

    private bool HaveWrongNumberOfButtonsBeenClicked()
    {
        return (buttonsEntered.Count != combination.GetCombinationLength());
    }

    private bool CheckCombination()
    {
        for (int buttonIndex = 0; buttonIndex < buttonsEntered.Count; ++buttonIndex)
        {
            if (IsCorrectButton(buttonIndex) == false)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsCorrectButton(int buttonIndex)
    {
        if (IsWrongEntry(buttonIndex))
        {
            return false;
        }
        return true;
    }

    private bool IsWrongEntry(int buttonIndex)
    {
        if (buttonsEntered[buttonIndex] == combination.GetCombinationDigit(buttonIndex))
        {
            return false;
        }
        return true;
    }

    private void Unlock()
    {
        Background.HideUnlockButton();
        Background.ChangeToSuccessColor();
    }

    private void FailToUnlock()
    {
        Background.ChangeToFailColor();
        StartCoroutine(ResetBackgroundColor());
    }

    // Co-routine example
    private IEnumerator ResetBackgroundColor()
    {
        yield return new WaitForSeconds(0.25f);

        Background.ChangeToDefaultColor();
    }

    private void ResetButtonEntries()
    {
        buttonsEntered = new List<int>();
    }
}
