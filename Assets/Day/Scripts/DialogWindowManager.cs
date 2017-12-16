using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animation))]
public class DialogWindowManager : MonoBehaviour {

    public Transform hoursContainer, minutesContainer;
    public Button buttonPrototype;

    private static string hoursChoosed = "00", minutesChoosed = "00";
    private Animation anim;

    static public string getHours()
    {
        return hoursChoosed;
    }

    static public string getMinutes()
    {
        return minutesChoosed;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        anim.Play("DM show");
    }

    public void Deactivate()
    {
        StartCoroutine(Deactivating());
    }

    IEnumerator Deactivating()
    {
        anim.Play("DM hide");
        yield return new WaitForSeconds(anim["DM hide"].length);
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        anim = GetComponent<Animation>();

        for (int i = 0; i < 24; ++i)
        {
            Button newButton = Instantiate(buttonPrototype, hoursContainer) as Button;
            string iD2 = i.ToString("D2");
            newButton.name = iD2;
            newButton.GetComponentInChildren<Text>().text = iD2;
            newButton.onClick.AddListener(delegate { hoursChoosed = iD2; });
        }

        for (int i = 0; i < 60; ++i)
        {
            Button newButton = Instantiate(buttonPrototype, minutesContainer) as Button;
            string iD2 = i.ToString("D2");
            newButton.name = iD2;
            newButton.GetComponentInChildren<Text>().text = iD2;
            newButton.onClick.AddListener(delegate { minutesChoosed = iD2; });
        }
    }
}
