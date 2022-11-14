using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public List<Text> TextList;

    public void ChangeTextShown(int textToShow)
    {
        for (int iPos = 0; iPos < 8; ++iPos)
        {
            if (TextList[iPos] != TextList[textToShow])
            {
                // Set the other captions to false
                TextList[iPos].gameObject.SetActive(false);
            }
            else
            {
                TextList[iPos].gameObject.SetActive(true);
            }
        }
    }

    public void ResetText()
    {
        for (int i = 0; i < 8; ++i)
        {
            // Set all text to be inactive
            TextList[i].gameObject.SetActive(false);
        }

        TextList[0].gameObject.SetActive(true);
    }

}
