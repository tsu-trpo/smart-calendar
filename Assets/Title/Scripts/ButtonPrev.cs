using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrev : MonoBehaviour {

    public MonthView monthView;

    private void OnMouseDown()
    {
        if (monthView == null)
        {
            Debug.Log("Ругаемся!");
        }

        else {
            monthView.PreviousMonth();
        }
           
    }
}
