using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class text : MonoBehaviour {

    public Text data_text;
    public DateTime Now = DateTime.Now;
    // Use this for initialization
    void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
        Now.Text = Now;
    }
}
