using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCreate : MonoBehaviour {


    private static float x =-2.5f, y=3.5f;

        public GameObject target;


	// Use this for initialization
	void Start () {
        for(int i=0; i<5; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                GameObject.Instantiate(target, new Vector3(x, y, 0), Quaternion.identity);
                x += 0.8f;
            }
            y -= 0.8f;
            x = -2.5f;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
