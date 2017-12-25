using UnityEngine;
using UnityEngine.UI;

public class TimeButton : MonoBehaviour {

	public Text buttonTextUI;

    string ButtonText
    {
        get
        {
            return buttonTextUI.GetComponentInChildren<Text>().text;
        }
        set
        {
            buttonTextUI.GetComponentInChildren<Text>().text = value;
        }
    }

    public void setName(string newName)
    {
        name = newName;
    }
}
