using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Text text;


    public void SetText(int day) {
        text = this.gameObject.transform.GetChild(0).GetComponent<Text>();
        text.text = day.ToString();
    }

    private void OnMouseUp()
    {
        Debug.Log("Clicked!");
    }



}
