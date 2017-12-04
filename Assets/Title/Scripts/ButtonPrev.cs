using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrev : MonoBehaviour {

    private MonthView monthView;

    private void OnMouseDown()
    {
        monthView.PreviousMonth();
    }

    void Start()
    {
        monthView = this.GetComponentInParent<MonthView>();
    }
}
