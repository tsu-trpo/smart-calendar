using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public float onPressedScale;

    Vector3 prevScale;

    void OnMouseDown()
    {
        prevScale = transform.localScale;
        transform.localScale = prevScale * onPressedScale;
    }

    void OnMouseUp()
    {
        transform.localScale = prevScale;
    }
}
