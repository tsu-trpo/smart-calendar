using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNext : MonoBehaviour {

    private MonthView monthView;

    private void OnMouseDown()
    {
        monthView.NextMonth();
    }

    void Start()
    {
        monthView = this.GetComponentInParent<MonthView>();
    }
}
