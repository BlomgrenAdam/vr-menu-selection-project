using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DistortedScaleSelection : MonoBehaviour
{
    public Vector3 scale; // Den förvrängda skalan för denna knapp
    public GameObject targetObject; // Objektet som ska ändra skala

    void Start()
    {
        // Eventuell initialisering om behövs
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on DistortedScaleButton: " + scale);
        targetObject.transform.localScale = scale; // Ändra objektets skala
    }
}
