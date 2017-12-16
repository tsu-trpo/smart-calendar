using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IssueManager : MonoBehaviour {

    public GameObject dialogWindow, prototype, closeButton;
    public InputField IssueInput;
    public Transform container;

    private void Awake()
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
        if (dialogWindow.activeSelf)
        {
            if (IssueInput.text.Length > 3)
            {
                Instantiate(spawnIssue(IssueInput.text, DialogWindowManager.getHours() + ":" + DialogWindowManager.getMinutes()), container);
                IssueInput.text = "";
                dialogWindow.GetComponent<DialogWindowManager>().Deactivate();
                closeButton.GetComponent<CloseButton>().Deactivate();
            }
        }
        else
        {
            closeButton.GetComponent<CloseButton>().Activate();
            dialogWindow.GetComponent<DialogWindowManager>().Activate();
        }
    }


}
