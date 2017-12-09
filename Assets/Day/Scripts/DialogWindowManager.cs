using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogWindowManager : MonoBehaviour {

    public Transform hoursContainer, minutesContainer;
    public Button buttonPrototype;

    public static string hoursChoosed = "00", minutesChoosed = "00";

    private void Start()
    {
        for (int i = 0; i < 24; ++i)
        {
            Button newButton = Instantiate(buttonPrototype, hoursContainer) as Button;
            newButton.name = i.ToString("D2");
            newButton.GetComponentInChildren<Text>().text = i.ToString("D2");
            }

        for (int i = 0; i < 60; ++i)
        {
            Button newButton = Instantiate(buttonPrototype, minutesContainer) as Button;
            newButton.name = i.ToString("D2");
            newButton.GetComponentInChildren<Text>().text = i.ToString("D2");
        }
    }
}
