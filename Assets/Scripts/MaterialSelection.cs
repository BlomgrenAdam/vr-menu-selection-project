using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MaterialSelection : MonoBehaviour
{
    public Material material; // Materialet för denna knapp
    public GameObject targetObject; // Objektet som ska ändra material

    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        objRenderer.material = material; // Ställ in materialet på knappen
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on MaterialButton: " + material.name);
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material = material; // Ändra objektets material
    }
}
