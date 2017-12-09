using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IssueManager : MonoBehaviour {

    public GameObject dialogWindow, prototype;
    public InputField IssueInput;
    public Transform container;
    private float y = 2.5f;
    private bool isPressed = false;

    private void Start()
    {
        dialogWindow.SetActive(false);
    }

    private void OnMouseUp()
    {
        if (isPressed)
        {
            if (IssueInput.text.Length > 3)
            {
                //how to create prototype constructor with 2 strings as params?
                GameObject newIssue = Instantiate(prototype, new Vector3(0, y, 0), Quaternion.identity, container) as GameObject;
                newIssue.GetComponentInChildren<Text>().text = IssueInput.text;
                //IssueInput.text = "";
                dialogWindow.SetActive(false);
                isPressed = false;
                y -= 1;
            }
        }
        else
        {
            dialogWindow.SetActive(true);
            isPressed = true;
        }
    }
}
