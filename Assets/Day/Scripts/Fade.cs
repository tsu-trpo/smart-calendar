using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Text txt;
    
	void Start ()
    {
        txt = GetComponent<Text>();
	}
	
	void Update ()
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time, 1.0f));
	}
}
