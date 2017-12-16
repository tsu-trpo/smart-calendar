using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public float length;
    private Text text;

    void Start ()
    {
        text = GetComponent<Text>();
    }
    
    void Update ()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.PingPong(Time.time, length));
    }
}
