using UnityEngine;

public class IssueManager : MonoBehaviour
{

    public GameObject dialogWindow, prototype, closeButton;
    public Transform issuesContainer;

    private DialogWindowManager dialogWindowManager;
    private CloseButtonDriver closeButtonDriver;

    private const int minIssueLength = 4;

    private void Awake()
    {
        dialogWindowManager = dialogWindow.GetComponent<DialogWindowManager>();
        dialogWindow.SetActive(false);
        closeButtonDriver = closeButton.GetComponent<CloseButtonDriver>();
    }

    private void OnMouseUp()
    {
        if (dialogWindow.activeSelf)
        {
            if (dialogWindowManager.IssueText.Length >= minIssueLength) //Create new issue if length is not too short
            {
                string selectedTime = dialogWindowManager.SelectedHours + ":" + dialogWindowManager.SelectedMinutes;
                Issue newIssue = Instantiate(prototype, issuesContainer).GetComponent<Issue>();
                newIssue.IssueText = dialogWindowManager.IssueText;
                newIssue.IssueTime = selectedTime;
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