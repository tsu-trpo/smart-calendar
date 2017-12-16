using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public float onPressedScale;

    Vector3 prevScale;

    private void Awake()
    {
        prevScale = transform.localScale;
    }

    void OnMouseDown()
    {
        transform.localScale = prevScale * onPressedScale;
    }

    void OnMouseUp()
    {
        transform.localScale = prevScale;
    }
}
