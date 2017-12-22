using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animation))]
public class CloseButton : MonoBehaviour
{
    public GameObject dialogWindow;

    CircleCollider2D buttonCollider;
    Animation buttonAnimation;
    DialogWindowManager dialogWindowManager;

    const string BUTTON_UP_ANIM = "Button up";
    const string BUTTON_DOWN_ANIM = "Button down";

    private void Awake()
    {
        buttonCollider = GetComponent<CircleCollider2D>();
        buttonAnimation = GetComponent<Animation>();
        dialogWindowManager = dialogWindow.GetComponent<DialogWindowManager>();
    }

    private void OnMouseUp()
    {
        dialogWindowManager.Deactivate();
        Deactivate();
    }

    public void Activate()
    {
        buttonCollider.enabled = true;
        buttonAnimation.Play(BUTTON_UP_ANIM);
    }

    public void Deactivate()
    {
        buttonCollider.enabled = false;
        buttonAnimation.Play(BUTTON_DOWN_ANIM);
    }
}
