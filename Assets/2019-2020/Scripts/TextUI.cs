using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public Text displayText;

    public void DisplayText()
    {
        displayText.text = "Display Text";
    }
}