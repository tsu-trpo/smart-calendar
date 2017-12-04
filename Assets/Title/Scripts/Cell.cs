using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Text text;
    private DateTime date;

    public void SetDate(DateTime _date)
    {
        date = _date;
        text = this.gameObject.transform.GetChild(0).GetComponent<Text>();
        text.text = date.Day.ToString();
    }

    public void SetColorGray()
    {
        text.color = Color.gray;
    }

    public void ClearColor()
    {
        text.color = Color.black;
    }

    private void OnMouseUp()
    {
        Debug.Log("Clicked! on " + date.ToString("yyyy MMMM dd"));
    }
}
