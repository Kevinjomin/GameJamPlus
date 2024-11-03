using UnityEngine;
using UnityEngine.UI;

public class Sub_CustomButton : MonoBehaviour
{
    public Sub_CustomButton upButton; // The button to navigate to when pressing W
    public Sub_CustomButton downButton; // The button to navigate to when pressing S

    private Button button;
    private Image buttonImage;

    void Awake()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
    }

    // Simulates clicking the button
    public void ClickButton()
    {
        button.onClick.Invoke();
    }

    // Highlights or unhighlights the button
    public void SetHighlight(bool highlight)
    {
        // Set button color or appearance based on highlight status
        if (buttonImage != null)
        {
            buttonImage.color = highlight ? Color.yellow : Color.white; // Change the button's image color
        }
    }
}
