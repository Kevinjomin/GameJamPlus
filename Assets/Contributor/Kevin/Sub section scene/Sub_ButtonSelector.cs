using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_ButtonSelector : MonoBehaviour
{
    public Sub_CustomButton initialButton; // Initial button to select at the start
    public Sub_CustomButton currentButton; // Currently selected button

    [SerializeField] private List<Sub_CustomButton> buttons = new List<Sub_CustomButton>();
    public GameEvent onSectionTwoStart;

    void Start()
    {
        SetCurrentButton(initialButton);
    }

    void Update()
    {
        if (currentButton == null) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            SetCurrentButton(currentButton.upButton);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetCurrentButton(currentButton.downButton);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentButton.ClickButton();
        }
    }

    private void SetCurrentButton(Sub_CustomButton newButton)
    {
        if (newButton != null)
        {
            currentButton = newButton;
            HighlightButton(currentButton);
        }
    }

    private void HighlightButton(Sub_CustomButton button)
    {
        foreach (Sub_CustomButton btn in buttons)
        {
            btn.SetHighlight(false);
        }
        button.SetHighlight(true);
    }

    public void OnButtonSelected()
    {
        StartCoroutine(DelayedEventTrigger());
    }

    private IEnumerator DelayedEventTrigger()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Triggering second section");
        onSectionTwoStart.TriggerEvent();
    }
}
