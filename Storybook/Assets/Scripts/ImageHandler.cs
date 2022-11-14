using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{
    public List<Image> ImageList;

    public void ChangeImageShown(int imageToShow)
    {
        for (int iPos = 0; iPos < 8; ++iPos)
        {
            if (ImageList[iPos] != ImageList[imageToShow])
            {
                // Set the other images to false
                ImageList[iPos].gameObject.SetActive(false);
            }
            else
            {
                ImageList[iPos].gameObject.SetActive(true);
            }
        }
    }

    public void ResetImages()
    {
        for (int i = 0; i < 8; ++i)
        {
            // Set all images to be inactive
            ImageList[i].gameObject.SetActive(false);
        }

        ImageList[0].gameObject.SetActive(true);
    }
}
