using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    void OnMouseDown()
    {
        transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1.00f, 1.00f, 1.00f);
    }
}
