using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellCreate : MonoBehaviour
{
    public GameObject target;
    public GameObject Canvas;
    public DateTime month = DateTime.Now;
    private Cell[] matrix = new Cell[42];
    float x = -2.5f, y = 3.5f;


    private int[] GetArrayOfdates()     //to create lists of days !!!!!!!! TO DO! !!!!!!!!!
    {
        int[] days = new int[42];
        DateTime day = new DateTime(month.Year, month.Month, month.Day);

        DateTime lastOfPrevMonth = new DateTime(day.Year, day.Month, 1).AddDays(-1);
        int dayOfWeek = (int) lastOfPrevMonth.DayOfWeek;
        int firstPrintDay = lastOfPrevMonth.Day - dayOfWeek + 1;
        int j = 0;

        for(int i = firstPrintDay; i<=lastOfPrevMonth.Day; i++)
        {
            days[j] = i;
            j++;
        }

        for (int i = 1; i <= DateTime.DaysInMonth(day.Year, day.Month); i++)
        {
            days[j] = i;
            j++;
        }

        for(int i=1; j<42; j++)
        {
            days[j] = i++;
        }   
        return days; 
    }

    public void printMonth()
    {
        int[] days = GetArrayOfdates();
        for (int i = 0; i < 42; i++)
        {
                matrix[i].SetText(days[i]);
        }
    }

    private void Start()
    {
        int[] days = GetArrayOfdates();
        int k = 0;
        GameObject cellGO;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                cellGO = Instantiate(target, new Vector3(x, y, 0), Quaternion.identity);
                cellGO.transform.SetParent(Canvas.transform);
                matrix[k] = cellGO.GetComponent<Cell>();
                matrix[k].SetText(days[k]);
                x += 0.8f;
                k++;
            }
            y -= 0.8f;
            x = -2.5f;
        }
    }
}
