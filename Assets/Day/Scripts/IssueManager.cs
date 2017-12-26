using UnityEngine;

public class IssueManager : MonoBehaviour
{

    public GameObject dialogWindow, prototype, closeButton;
    public Transform issuesContainer;

    DialogWindowManager dialogWindowManager;
    CloseButtonDriver closeButtonDriver;

    const int minIssueLength = 4;

    private void Awake()
    {
        dialogWindowManager = dialogWindow.GetComponent<DialogWindowManager>();
        dialogWindow.SetActive(false);
        closeButtonDriver = closeButton.GetComponent<CloseButtonDriver>();
    }

    private GameObject spawnIssue(string issueText, string issueTime)
    {
        GameObject issueClone = prototype;
        Issue issue = issueClone.GetComponent<Issue>();
        issue.IssueText = issueText;
        issue.IssueTime = issueTime;
        return issueClone;
    }

    private void OnMouseUp()
    {
        if (dialogWindow.activeSelf)
        {
            if (dialogWindowManager.IssueText.Length >= minIssueLength) //Create new issue if length is not too short
            {
                string selectedTime = dialogWindowManager.SelectedHours + ":" + dialogWindowManager.SelectedMinutes;
                Instantiate(spawnIssue(dialogWindowManager.IssueText, selectedTime), issuesContainer);
                dialogWindowManager.Deactivate();
                closeButtonDriver.Deactivate();
            }
            else
            {
                dialogWindowManager.ClearInputField(minIssueLength);
            }
        }
        else
        {
            closeButtonDriver.Activate();
            dialogWindowManager.Activate();
        }
    }
}