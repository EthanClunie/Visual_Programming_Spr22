using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public int ButtonValue;
    public Keypad Keypad;

    public void OnClick()
    {
        // Tell the keypad that the button was clicked and tell it the button's value
        Keypad.RegisterButtonClick(ButtonValue);
    }
}
