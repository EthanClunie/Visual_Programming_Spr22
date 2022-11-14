using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ImageHandler ImageHandler;
    public TextHandler TextHandler;

    public GameObject NextButton;
    public GameObject PreviousButton;

    private int listPosition;

    public void Reset()
    {
        listPosition = 0;
        HidePreviousButton();

        ImageHandler.ResetImages();
        TextHandler.ResetText();
    }

    public void OnNextClick()
    {
        GoNextPage();
    }

    public void OnPreviousClick()
    {
        GoPreviousPage();
    }

    private void GoNextPage()
    {
        ++listPosition;

        ImageHandler.ChangeImageShown(listPosition);
        TextHandler.ChangeTextShown(listPosition);

        if (listPosition >= 7)
        {
            ShowPreviousButton();
            HideNextButton();
        }
        else
        {
            ShowNextButton();
            ShowPreviousButton();
        }
    }

    private void GoPreviousPage()
    {
        --listPosition;

        ImageHandler.ChangeImageShown(listPosition);
        TextHandler.ChangeTextShown(listPosition);

        if (listPosition <= 0)
        {
            HidePreviousButton();
            ShowNextButton();
        }
        else
        {
            ShowPreviousButton();
        }
    }

    private void HideNextButton()
    {
        NextButton.SetActive(false);
    }

    private void HidePreviousButton()
    {
        PreviousButton.SetActive(false);
    }

    private void ShowNextButton()
    {
        NextButton.SetActive(true);
    }

    private void ShowPreviousButton()
    {
        PreviousButton.SetActive(true);
    }
}
