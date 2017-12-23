using UnityEngine;
using UnityEngine.UI;

public class Issue : MonoBehaviour
{
    [SerializeField]
    private Text issueText, issueTime;

    public string IssueText
    {
        get
        {
            return issueText.text;
        }
        set
        {
            issueText.text = value;
        }
    }

    public string IssueTime
    {
        get
        {
            return issueTime.text;
        }
        set
        {
            issueTime.text = value;
        }
    }
}
