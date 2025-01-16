using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu; // Huvudmenyn
    public GameObject[] colorButtons; // Dra in färgknapparna här

    private bool colorButtonsVisible = false; // Spårar om färgknapparna är synliga

    public void ToggleColorButtons()
    {
        colorButtonsVisible = !colorButtonsVisible; // Växla mellan true/false

        foreach (GameObject button in colorButtons)
        {
            button.SetActive(colorButtonsVisible); // Visa eller dölj färgknapparna
        }
    }
}
