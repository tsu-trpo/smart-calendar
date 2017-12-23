using System.Collections.Generic;
using UnityEngine;

public class IssueManager : MonoBehaviour
{
    private static Dictionary<System.DateTime, List<GameObject>> issuesMap = new Dictionary<System.DateTime, List<GameObject>>();

    public GameObject dialogWindow, prototype, closeButton;
    public Transform issuesContainer;

    DialogWindowManager dialogWindowManager;
    CloseButtonDriver closeButtonDriver;

    private System.DateTime selectedDate = System.DateTime.Today;

    public void SetDate(System.DateTime date)
    {
        selectedDate = date;
        Issue[] childIssues = issuesContainer.GetComponentsInChildren<Issue>();
        foreach (Issue children in childIssues)
        {
            children.gameObject.SetActive(false);
        }
        List<GameObject> issues;
        if (issuesMap.TryGetValue(selectedDate, out issues))
        {
            foreach (GameObject issueCell in issues)
            {
                issueCell.SetActive(true);
                //Instantiate(issueCell, issuesContainer);
            }
        }
    }

    private void Awake()
    {
        dialogWindowManager = dialogWindow.GetComponent<DialogWindowManager>();
        dialogWindow.SetActive(false);
        closeButtonDriver = closeButton.GetComponent<CloseButtonDriver>();
    }

    private GameObject spawnIssue(string issueText, string issueTime)
    {
        GameObject issueClone = prototype;
        issueClone.GetComponent<Issue>().IssueText = issueText;
        issueClone.GetComponent<Issue>().IssueTime = issueTime;
        return issueClone;
    }

    private void OnMouseUp()
    {
        if (dialogWindow.activeSelf)
        {
            if (dialogWindowManager.IssueText.Length > 3) //Create new issue if lenght > 3
            {
                string selectedTime = dialogWindowManager.SelectedHours + ":" + dialogWindowManager.SelectedMinutes;
                GameObject newIssue = Instantiate(spawnIssue(dialogWindowManager.IssueText, selectedTime), issuesContainer) as GameObject;
                if (!issuesMap.ContainsKey(selectedDate))
                {
                    issuesMap.Add(selectedDate, new List<GameObject>());
                }
                issuesMap[selectedDate].Add(newIssue);
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