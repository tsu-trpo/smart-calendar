using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class today : MonoBehaviour
{

    // Use this for initialization
    DateTime Now = DateTime.Now;
    void Start()
    {
        //print(Now.DayOfWeek + " " +Now.ToString());
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 100, 100), Now.ToString());
    }

}
