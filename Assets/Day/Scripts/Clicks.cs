using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicks : MonoBehaviour
{
    private Image img;
    void OnMouseDown ()
    {
        print("Click");
        
    }

    private void OnMouseUp()
    {
        Debug.Log("Unclick");
    }
}
