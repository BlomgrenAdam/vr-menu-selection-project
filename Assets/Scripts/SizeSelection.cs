using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SizeSelection : MonoBehaviour
{
    public Vector3 size; // Storleken f�r denna knapp
    public GameObject targetObject; // Objektet som ska �ndra storlek

    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on SizeButton: " + size);
        targetObject.transform.localScale = size; // �ndra objektets storlek
    }
}
