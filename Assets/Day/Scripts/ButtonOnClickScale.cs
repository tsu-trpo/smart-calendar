using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnClickScale : MonoBehaviour
{
    public float onPressedScale = 0.85f;

    Vector3 initScale;

    private void Awake()
    {
        initScale = transform.localScale;
    }

    void OnMouseDown()
    {
        transform.localScale = initScale * onPressedScale;
    }

    void OnMouseUp()
    {
        transform.localScale = initScale;
    }
}