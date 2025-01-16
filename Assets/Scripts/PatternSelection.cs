using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PatternSelection : MonoBehaviour
{
    public Material patternMaterial; // Materialet för denna knapp, innehållande mönstret
    public GameObject targetObject; // Objektet som ska ändra mönster

    void Start()
    {
        // Eventuell initialisering om behövs
    }


    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on PatternButton: " + patternMaterial.name);
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material = patternMaterial; // Ändra objektets material till mönstret
    }
}
