using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IssueManager : MonoBehaviour {

    public GameObject dialogWindow, prototype;
    public InputField IssueInput;
    public Transform container;
    private bool isPressed = false;

    private void Start()
    {
        dialogWindow.SetActive(false);
    }

    private GameObject spawnIssue(string issueText, string issueTime)
    {
        GameObject issueClone = prototype;
        Text[] texts = issueClone.GetComponentsInChildren<Text>();
        texts[0].text = issueText;
        texts[1].text = issueTime;
        return issueClone;
    }

    private void OnMouseUp()
    {
        if (isPressed)
        {
            if (IssueInput.text.Length > 3)
            {
                //how to create prototype constructor with 2 strings as params?
                Instantiate(spawnIssue(IssueInput.text, DialogWindowManager.getHours() + ":" + DialogWindowManager.getMinutes()), container);
                IssueInput.text = ""; //DONT REMEMBER TO REMOVE IT
                dialogWindow.SetActive(false);
                isPressed = false;
            }
        }
        else
        {
            dialogWindow.SetActive(true);
            isPressed = true;
        }
    }
}
