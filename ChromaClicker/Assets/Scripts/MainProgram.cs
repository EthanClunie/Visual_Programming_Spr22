using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainProgram : MonoBehaviour
{
    public Button ButtonColor;
    public Text ButtonText;

    public void OnButtonClick()
    {
        ButtonColor.GetComponent<Image>().color = Randomizer();
        ButtonText.color = Randomizer();
    }

    public Color Randomizer()
    {
        return new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
