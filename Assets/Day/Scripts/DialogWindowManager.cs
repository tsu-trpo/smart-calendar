using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
public class DialogWindowManager : MonoBehaviour
{
    public Transform hoursContainer, minutesContainer;
    public InputField issueInput; //How to setpossibility set references only at inspector?
    public Button buttonPrototype;

    public int SelectedHours
    {
        get
        {
            return _selectedHours;
        }
    }

    public int SelectedMinutes
    {
        get
        {
            return _selectedMinutes;
        }
    }

    public string IssueText
    {
        get
        {
            return issueInput.text;
        }
    }

    private int _selectedHours = 0, _selectedMinutes = 0;

    const int NUMBER_OF_HOURS = 24;
    const int NUMBER_OF_MINUTES = 60;

    private Animation anim;
    private Text inputPlaceholderText;

    const string SHOW_DM_ANIM = "DM show";
    const string HIDE_DM_ANIM = "DM hide";

    public void Activate()
    {
        gameObject.SetActive(true);
        anim.Play(SHOW_DM_ANIM);
    }

    public void Deactivate()
    {
        StartCoroutine(Deactivating());
    }

    IEnumerator Deactivating()
    {
        anim.Play(HIDE_DM_ANIM);
        yield return new WaitForSeconds(anim[HIDE_DM_ANIM].length);
        issueInput.text = string.Empty;
        gameObject.SetActive(false);
    }

    public void ClearInputField(int minimumCharacters)
    {
        issueInput.text = string.Empty;
        inputPlaceholderText.text = "Enter issue text(at least " + minimumCharacters + " symbols)...";
    }

    private void Awake()
    {
        anim = GetComponent<Animation>();
        inputPlaceholderText = issueInput.placeholder.GetComponent<Text>();

        for (int hour = 0; hour < NUMBER_OF_HOURS; ++hour)
        {
            Button newButton = Instantiate(buttonPrototype, hoursContainer) as Button;
            TimeButton timeButton = newButton.GetComponent<TimeButton>();
            string formattedHour = hour.ToString("D2");
            timeButton.Name = formattedHour;
            timeButton.ButtonText = formattedHour;
            newButton.onClick.AddListener(() => TaskForHourButtons(hour));
        }

        for (int minute = 0; minute < NUMBER_OF_MINUTES; ++minute)
        {
            Button newButton = Instantiate(buttonPrototype, minutesContainer) as Button;
            TimeButton timeButton = newButton.GetComponent<TimeButton>();
            string formattedMinute = minute.ToString("D2");
            timeButton.Name = formattedMinute;
            timeButton.ButtonText = formattedMinute;
            newButton.onClick.AddListener(() => TaskForMinuteButtons(minute));
        }
    }

    void TaskForHourButtons(int hour)
    {
        _selectedHours = hour;
    }

    void TaskForMinuteButtons(int minute)
    {
        _selectedMinutes = minute;
    }
}
