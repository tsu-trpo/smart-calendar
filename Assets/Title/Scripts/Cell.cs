using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Text text;
    private DateTime date;
    private MonthView month;
    private int number;
    private bool isExist = true;  //activity, true is basic state;

    public void SetDate(DateTime _date)
    {
        date = _date;
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

    public void SetColorToday()
    {
        text.color = Color.red;
    }

    private void OnMouseUp()
    {
        month = this.transform.GetComponentInParent<MonthView>();
        Debug.Log("Clicked! on " + date.ToString("yyyy MMMM dd"));
        month.ChangePushed(number);
    }

    private void Awake()
    {
        text = this.gameObject.transform.GetChild(0).GetComponent<Text>();
    }

    public void ChangeState()
    {
        isExist = !isExist;
        gameObject.SetActive(isExist);
    }

    public void SetBackgroundOn()
    {
        this.transform.GetComponent<MeshRenderer>().enabled = true;
    }

    public void SetBackgroundOff()
    {
        this.transform.GetComponent<MeshRenderer>().enabled = false;
    }

    public void SetNumber(int _number)
    {
        number = _number;
    }
}
