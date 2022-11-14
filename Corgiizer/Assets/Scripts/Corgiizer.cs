using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corgiizer : MonoBehaviour
{
    public Image CorgiImage;
    public List<Sprite> CorgiSprites;
    public CanvasGroup CorgiImageCanvasGroup;

    private bool isShowingImage = true;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomImage();
    }

    public void OnToggleClick()
    {
        ToggleVisibility();
    }

    public void OnCorgiizeClick()
    {
        SetRandomImage();
    }

    private void SetRandomImage()
    {
        int imageToSet = GetRandomInt();
        CorgiImage.sprite = CorgiSprites[imageToSet];
    }

    private void ToggleVisibility()
    {
        if (isShowingImage)
        {
            CanvasGroupDisplayer.Hide(CorgiImageCanvasGroup);
            isShowingImage = false;
        }
        else
        {
            CanvasGroupDisplayer.Show(CorgiImageCanvasGroup);
            isShowingImage = true;
        }
    }

    private int GetRandomInt()
    {
        return Random.Range(0, 12);
    }
}
