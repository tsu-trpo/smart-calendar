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
    private MeshRenderer meshRenderer;

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
        month.SelectDay(number);
    }

    private void Awake()
    {
        text = this.gameObject.transform.GetChild(0).GetComponent<Text>();
        meshRenderer = this.transform.GetComponent<MeshRenderer>();
    }

    public void Turn_OnOff()
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
        meshRenderer.enabled = false;
    }

    public void SetDay(int _number)
    {
        number = _number;
    }
}
