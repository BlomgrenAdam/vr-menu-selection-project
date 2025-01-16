using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorSelection : MonoBehaviour
{
    public Color color; // Färgen för denna knapp
    public GameObject targetObject; // Objektet som ska ändra färg

    private Renderer objRenderer;
    private Color originalColor;


    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
        objRenderer.material.color = color; // Ställ in färgen på knappen
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        objRenderer.material.color = Color.yellow; // Highlight-färg
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        objRenderer.material.color = originalColor; // Återställ till originalfärgen
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ColorButton: " + color);
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material.color = color; // Ändra objektets färg
    }
}
