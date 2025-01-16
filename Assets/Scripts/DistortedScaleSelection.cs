using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DistortedScaleSelection : MonoBehaviour
{
    public Vector3 scale; // Den f�rvr�ngda skalan f�r denna knapp
    public GameObject targetObject; // Objektet som ska �ndra skala

    void Start()
    {
        // Eventuell initialisering om beh�vs
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on DistortedScaleButton: " + scale);
        targetObject.transform.localScale = scale; // �ndra objektets skala
    }
}
