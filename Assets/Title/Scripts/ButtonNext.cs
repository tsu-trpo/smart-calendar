using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNext : MonoBehaviour
{
    public MonthView monthView;

    private void OnMouseDown()
    {
        if (monthView == null)
        {
            Debug.LogError("Button doesn't have monthView");
            return;
        }

        monthView.NextMonth();
    }
}