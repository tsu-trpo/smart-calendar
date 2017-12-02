using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour {

    private static float y = 3;

    public GameObject target;
    public Transform container;

    void OnMouseUp()
    {
        GameObject.Instantiate(target, new Vector3(0, y, 0), Quaternion.identity, container);
        y -= 1;
    }
}