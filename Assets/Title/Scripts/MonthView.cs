using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthView : MonoBehaviour {
    public GameObject target;
    public GameObject canvas;
    private DateTime month = DateTime.Now;
    private Cell[] ArrayOfCells = new Cell[42];
    private Text thisMonth;
    private const int countOfRows = 6;
    private const int countOfColumns = 7;

    private void Start()
    {
        thisMonth = this.transform.GetChild(1).GetComponent<Text>();
        CreatCells();
        PrintMonth();
    }

    private void CreatCells()
    {
        float  y = 3f;
        for (int i = 0; i < countOfRows; i++)
        {
            float x = -2.5f;
            for (int j = 0; j < countOfColumns; j++)
            {
                GameObject CellGO;
                CellGO = Instantiate(target, new Vector3(x, y, 0), Quaternion.identity);
                CellGO.transform.SetParent(canvas.transform);
                ArrayOfCells[countOfColumns*i+j] = CellGO.GetComponent<Cell>();
                x += 0.8f;
            }
            y -= 0.8f;
        }
    }

    private void PrintMonth()
    {
        thisMonth.text = month.ToString("MMMM yyyy");
        DateTime lastOfPrevMonth = new DateTime(month.Year, month.Month, 1).AddDays(-1);
        int dayOfWeek = (int)lastOfPrevMonth.DayOfWeek;
        int firstPrintDay = lastOfPrevMonth.Day - dayOfWeek + 1;    //Week starts from 0 e.g sunday is 0; 
        int counterOfArray = 0;

        for (int i = firstPrintDay; i <= lastOfPrevMonth.Day; i++)
        {
            ArrayOfCells[counterOfArray].SetDate(new DateTime(lastOfPrevMonth.Year, lastOfPrevMonth.Month, i));
            ArrayOfCells[counterOfArray].SetColorGray();
            counterOfArray++;
        }

        for (int i = 1; i <= DateTime.DaysInMonth(month.Year, month.Month); i++)
        {
            ArrayOfCells[counterOfArray].SetDate(new DateTime(month.Year,month.Month, i));
            ArrayOfCells[counterOfArray].ClearColor();
            counterOfArray++;
        }

        DateTime NextMonth = month.AddMonths(1);
        
        for (int i = 1; counterOfArray < ArrayOfCells.Length; counterOfArray++)
        {
            ArrayOfCells[counterOfArray].SetDate(new DateTime(NextMonth.Year, NextMonth.Month, i++));
            ArrayOfCells[counterOfArray].SetColorGray();
        }

        if (month.Month == DateTime.Today.Month)
        {
            int todayKey = dayOfWeek + DateTime.Today.Day-1;
            ArrayOfCells[todayKey].SetColorToday();
        }
    }

    public void NextMonth()
    {
        month = month.AddMonths(1);
        PrintMonth();
    }

    public void PreviousMonth()
    {
        month = month.AddMonths(-1);
        PrintMonth();
    }
}
