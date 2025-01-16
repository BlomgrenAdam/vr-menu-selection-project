using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorSelection : MonoBehaviour
{
    public Color color; // F�rgen f�r denna knapp
    public GameObject targetObject; // Objektet som ska �ndra f�rg

    private Renderer objRenderer;
    private Color originalColor;


    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
        objRenderer.material.color = color; // St�ll in f�rgen p� knappen
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        objRenderer.material.color = Color.yellow; // Highlight-f�rg
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        objRenderer.material.color = originalColor; // �terst�ll till originalf�rgen
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ColorButton: " + color);
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material.color = color; // �ndra objektets f�rg
    }
}
