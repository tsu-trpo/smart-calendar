using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthView : MonoBehaviour
{
    public GameObject target;
    public GameObject canvas;
    private DateTime month = DateTime.Now;
    private Cell[] ArrayOfCells = new Cell[countOfRows * countOfColumns];
    private Text thisMonth;
    private const int countOfRows = 6;
    private const int countOfColumns = 7;
    private int pushedCell = 0;

    private void Start()
    {
        thisMonth = this.transform.GetChild(1).GetComponent<Text>();
        CreatCells();
        PrintMonth();
    }

    private void CreatCells()
    {
        float y = 3f;
        for (int i = 0; i < countOfRows; i++)
        {
            float x = -2.15f;
            for (int j = 0; j < countOfColumns; j++)
            {
                GameObject CellGO;
                CellGO = Instantiate(target, new Vector3(x, y, 0), Quaternion.identity);
                CellGO.transform.SetParent(canvas.transform);
                ArrayOfCells[countOfColumns * i + j] = CellGO.GetComponent<Cell>();
                ArrayOfCells[countOfColumns * i + j].SetDay(countOfColumns * i + j);
                x += 0.7f;
            }
            y -= 0.8f;
        }
    }

    private void PrintMonth()
    {
        thisMonth.text = month.ToString("MMMM yyyy");
        DateTime lastOfPrevMonth = new DateTime(month.Year, month.Month, 1).AddDays(-1);
        int dayOfWeek = (int)lastOfPrevMonth.DayOfWeek;
        //Week starts from 0 e.g sunday is 0; 
        int firstPrintDay = lastOfPrevMonth.Day - dayOfWeek + 1;
        int counterOfArray = 0;

        for (int i = firstPrintDay; i <= lastOfPrevMonth.Day; i++)
        {
            ArrayOfCells[counterOfArray].SetDate(new DateTime(lastOfPrevMonth.Year, lastOfPrevMonth.Month, i));
            ArrayOfCells[counterOfArray].SetColorGray();
            counterOfArray++;
        }

        for (int i = 1; i <= DateTime.DaysInMonth(month.Year, month.Month); i++)
        {
            ArrayOfCells[counterOfArray].SetDate(new DateTime(month.Year, month.Month, i));
            ArrayOfCells[counterOfArray].ClearColor();
            counterOfArray++;
        }

        DateTime NextMonth = month.AddMonths(1);

        for (int i = 1; counterOfArray < ArrayOfCells.Length; counterOfArray++)
        {
            ArrayOfCells[counterOfArray].SetDate(new DateTime(NextMonth.Year, NextMonth.Month, i++));
            ArrayOfCells[counterOfArray].SetColorGray();
        }

        if (month.Month == DateTime.Today.Month && month.Year == DateTime.Today.Year)
        {
            int todayKey = dayOfWeek + DateTime.Today.Day - 1;
            ArrayOfCells[todayKey].SetColorToday();
        }
    }

    public void NextMonth()
    {
        month = month.AddMonths(1);
        PrintMonth();
        ArrayOfCells[pushedCell].SetBackgroundOff();
    }

    public void PreviousMonth()
    {
        month = month.AddMonths(-1);
        PrintMonth();
        ArrayOfCells[pushedCell].SetBackgroundOff();
    }

    public void SelectDay(int index)
    {
        ArrayOfCells[pushedCell].SetBackgroundOff();
        ArrayOfCells[index].SetBackgroundOn();
        pushedCell = index;
    }

    public void SwitchCells()
    {
        for (int i = 0; i < countOfColumns * countOfRows; i++)
        {
            ArrayOfCells[i].Turn_OnOff();
        }

    }
}
