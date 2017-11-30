using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matrix : MonoBehaviour {

    CellCreate matrix;
    private Text thisMonth;

    private void OnMouseDown()
    {
        matrix.month = matrix.month.AddMonths(1);
        thisMonth.text = matrix.month.ToString("MMMM yyyy");
        matrix.printMonth();
    }

    void Start()
    {
        matrix = this.transform.parent.gameObject.GetComponent<CellCreate>();
        thisMonth = this.transform.parent.GetChild(2).GetComponent<Text>();
        thisMonth.text = matrix.month.ToString("MMMM yyyy");
    }

}
