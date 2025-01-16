using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    public void OnClick()
    {
        // Hantera knappens klick
        Debug.Log("Knappen klickades!");
    }

    private void OnMouseDown()
    {
        // Kontrollera specifikt om klicket är inom den synliga delen
        RectTransform rect = GetComponent<RectTransform>();
        Vector2 localMousePosition = rect.InverseTransformPoint(Input.mousePosition);

        if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition, null))
        {
            OnClick();
        }
    }
}
