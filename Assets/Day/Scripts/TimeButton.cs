﻿using UnityEngine;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour
{
    public Text buttonTextUI;

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public string ButtonText
    {
        get
        {
            return buttonTextUI.text;
        }
        set
        {
            buttonTextUI.text = value;
        }
    }
}