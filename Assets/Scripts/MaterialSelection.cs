using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MaterialSelection : MonoBehaviour
{
    public Material material; // Materialet f�r denna knapp
    public GameObject targetObject; // Objektet som ska �ndra material

    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        objRenderer.material = material; // St�ll in materialet p� knappen
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on MaterialButton: " + material.name);
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material = material; // �ndra objektets material
    }
}
