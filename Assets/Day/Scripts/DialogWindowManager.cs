using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
public class DialogWindowManager : MonoBehaviour
{
    public Transform hoursContainer, minutesContainer;
    public Button buttonPrototype;

    public string SelectedHours
    {
        get
        {
            return _selectedHours;
        }
    }

    public string SelectedMinutes
    {
        get
        {
            return _selectedMinutes;
        }
    }

    private string _selectedHours = "00", _selectedMinutes = "00";

    const int NUMBER_OF_HOURS = 24;
    const int NUMBER_OF_MINUTES = 60;

    private Animation anim;

    const string SHOW_ANIM = "DM show";
    const string HIDE_ANIM = "DM hide";

    public void Activate()
    {
        gameObject.SetActive(true);
        anim.Play(SHOW_ANIM);
    }

    public void Deactivate()
    {
        StartCoroutine(Deactivating());
    }

    IEnumerator Deactivating()
    {
        anim.Play("DM hide");
        yield return new WaitForSeconds(anim[HIDE_ANIM].length);
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        anim = GetComponent<Animation>();

        for (int hour = 0; hour < NUMBER_OF_HOURS; ++hour)
        {
            Button newButton = Instantiate(buttonPrototype, hoursContainer) as Button;
            string currentHour = hour.ToString("D2");
            newButton.name = currentHour;
            newButton.GetComponentInChildren<Text>().text = currentHour;
            newButton.onClick.AddListener(() => TaskForHourButtons(currentHour));
        }

        for (int minute = 0; minute < NUMBER_OF_MINUTES; ++minute)
        {
            Button newButton = Instantiate(buttonPrototype, minutesContainer) as Button;
            string currentMinute = minute.ToString("D2");
            newButton.name = currentMinute;
            newButton.GetComponentInChildren<Text>().text = currentMinute;
            newButton.onClick.AddListener(() => TaskForMinuteButtons(currentMinute));
        }
    }

    void TaskForHourButtons(string hour)
    {
        _selectedHours = hour;
    }

    void TaskForMinuteButtons(string minute)
    {
        _selectedMinutes = minute;
    }
}
