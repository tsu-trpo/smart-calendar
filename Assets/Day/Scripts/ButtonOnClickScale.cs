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
        transform.localScale.Set(onPressedScale, initScale.y, onPressedScale);
    }

    void OnMouseUp()
    {
        transform.localScale = initScale;
    }
}