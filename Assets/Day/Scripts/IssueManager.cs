using UnityEngine;

public class IssueManager : MonoBehaviour
{

    public GameObject dialogWindow, prototype, closeButton;
    public Transform issuesContainer;

    DialogWindowManager dialogWindowManager;
    CloseButtonDriver closeButtonDriver;

    private void Awake()
    {
        dialogWindowManager = dialogWindow.GetComponent<DialogWindowManager>();
        dialogWindow.SetActive(false);
        closeButtonDriver = closeButton.GetComponent<CloseButtonDriver>();
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
            if (dialogWindowManager.IssueText.Length > 3) //Create new issue if lenght > 3
            {
                string selectedTime = dialogWindowManager.SelectedHours + ":" + dialogWindowManager.SelectedMinutes;
                Instantiate(spawnIssue(dialogWindowManager.IssueText, selectedTime), issuesContainer);
                dialogWindowManager.Deactivate();
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