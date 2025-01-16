using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PatternSelection : MonoBehaviour
{
    public Material patternMaterial; // Materialet f�r denna knapp, inneh�llande m�nstret
    public GameObject targetObject; // Objektet som ska �ndra m�nster

    void Start()
    {
        // Eventuell initialisering om beh�vs
    }


    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on PatternButton: " + patternMaterial.name);
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material = patternMaterial; // �ndra objektets material till m�nstret
    }
}
