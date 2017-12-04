using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthView : MonoBehaviour {
    public GameObject target;
    public GameObject Canvas;
    public DateTime Month = DateTime.Now;
    private Cell[] ArrayOfCells = new Cell[42];
    private Text thisMonth;

    private void Start()
    {
        CreatCells();
        PrintMonth();
    }

    private void CreatCells()
    {
        float x = -2.5f, y = 3f;
        int k=0;
        GameObject CellGO;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                CellGO = Instantiate(target, new Vector3(x, y, 0), Quaternion.identity);
                CellGO.transform.SetParent(Canvas.transform);
                ArrayOfCells[k] = CellGO.GetComponent<Cell>();
                x += 0.8f;
                k++;
            }
            y -= 0.8f;
            x = -2.5f;
        }
    }

    private void PrintMonth()
    {
        thisMonth = this.transform.GetChild(1).GetComponent<Text>();
        thisMonth.text = Month.ToString("MMMM yyyy");
        DateTime lastOfPrevMonth = new DateTime(Month.Year, Month.Month, 1).AddDays(-1);
        int dayOfWeek = (int)lastOfPrevMonth.DayOfWeek;
        int firstPrintDay = lastOfPrevMonth.Day - dayOfWeek + 1;    //Week starts from 0 e.g sunday is 0; 
        int j = 0;

        for (int i = firstPrintDay; i <= lastOfPrevMonth.Day; i++)
        {
            ArrayOfCells[j].SetDate(new DateTime(lastOfPrevMonth.Year, lastOfPrevMonth.Month, i));
            ArrayOfCells[j].SetColorGray();
            j++;
        }

        for (int i = 1; i <= DateTime.DaysInMonth(Month.Year, Month.Month); i++)
        {
            ArrayOfCells[j].SetDate(new DateTime(Month.Year,Month.Month, i));
            ArrayOfCells[j].ClearColor();
            j++;
        }
        DateTime NextMonth = Month.AddMonths(1);
        for (int i = 1; j < 42; j++)
        {
            ArrayOfCells[j].SetDate(new DateTime(NextMonth.Year, NextMonth.Month, i++));
            ArrayOfCells[j].SetColorGray();
        }
    }

    public void NextMonth()
    {
        Month = Month.AddMonths(1);
        PrintMonth();
    }

    public void PreviousMonth()
    {
        Month = Month.AddMonths(-1);
        PrintMonth();
    }
}
