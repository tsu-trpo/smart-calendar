using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public float speed = 10f, checkPos = 20f;
    private RectTransform rec;
	
	void Start ()
    {
        rec = GetComponent<RectTransform>();
	}
	void Update ()
    {
		if(rec.offsetMin.x <= checkPos)
        {
            rec.offsetMin += new Vector2(speed, 0f);
            rec.offsetMax += new Vector2(speed, 0f);
        }
	}
}
