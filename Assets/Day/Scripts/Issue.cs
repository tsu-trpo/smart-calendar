using UnityEngine;
using UnityEngine.UI;

public class Issue : MonoBehaviour {

    public Text issueTextUI, issueTimeUI;

    public string IssueText
    {
        get
        {
            return issueTextUI.text;
        }
        set
        {
            issueTextUI.text = value;
        }
    }

    public string IssueTime
    {
        get
        {
            return issueTimeUI.text;
        }
        set
        {
            issueTimeUI.text = value;
        }
    }
}
