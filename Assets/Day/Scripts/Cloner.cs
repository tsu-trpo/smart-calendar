using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloner : MonoBehaviour {

    public GameObject target;
    public Transform container;

    void OnMouseUp()
    {
            GameObject.Instantiate(target, new Vector3(Random.Range(-3, 3), Random.Range(-5, 5), 0), Quaternion.identity, container);
    }
}
