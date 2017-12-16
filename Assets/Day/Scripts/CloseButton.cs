using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animation))]
public class CloseButton : MonoBehaviour {

    public GameObject dialogWindow;

    bool isActive = false;

    private void OnMouseUp()
    {
        dialogWindow.SetActive(false);
        Deactivate();
    }

    public void Activate()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<Animation>().Play("Button up");
    }

    public void Deactivate()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Animation>().Play("Button down");
    }

}
