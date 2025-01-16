using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu; // Huvudmenyn
    public GameObject[] colorButtons; // Dra in f�rgknapparna h�r

    private bool colorButtonsVisible = false; // Sp�rar om f�rgknapparna �r synliga

    public void ToggleColorButtons()
    {
        colorButtonsVisible = !colorButtonsVisible; // V�xla mellan true/false

        foreach (GameObject button in colorButtons)
        {
            button.SetActive(colorButtonsVisible); // Visa eller d�lj f�rgknapparna
        }
    }
}
