using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IssueManager : MonoBehaviour
{

    public GameObject dialogWindow, prototype, closeButton;
    public UnityEngine.UI.InputField issueInput;
    public Transform container;

    DialogWindowManager dialogWindowManager;
    CloseButton closeButtonDriver;

    private void Awake()
    {
        dialogWindowManager = dialogWindow.GetComponent<DialogWindowManager>();
        dialogWindow.SetActive(false);
        closeButtonDriver = closeButton.GetComponent<CloseButton>();
    }

    private GameObject spawnIssue(string issueText, string issueTime)
    {
        GameObject issueClone = prototype;
        UnityEngine.UI.Text[] texts = issueClone.GetComponentsInChildren<UnityEngine.UI.Text>();
        texts[0].text = issueText;
        texts[1].text = issueTime;
        return issueClone;
    }

    private void OnMouseUp()
    {
        if (dialogWindow.activeSelf)
        {
            if (issueInput.text.Length > 3)
            {
                string selectedTime = string.Empty;
                selectedTime += dialogWindowManager.SelectedHours;
                selectedTime += ":";
                selectedTime += dialogWindowManager.SelectedMinutes;
                Instantiate(spawnIssue(issueInput.text, selectedTime), container);
                dialogWindowManager.Deactivate();
                issueInput.text = string.Empty;
                closeButtonDriver.Deactivate();
            }
        }
        else
        {
            closeButtonDriver.Activate();
            dialogWindowManager.Activate();
        }
    }
}