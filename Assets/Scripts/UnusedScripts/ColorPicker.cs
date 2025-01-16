using UnityEngine;
using System.Collections; // Ensure this is added to use IEnumerator

public class ColorPicker : MonoBehaviour
{
    public Material[] colorOptions; // Array of color materials
    public GameObject targetSphere; // Reference to the sphere to change color

    private Renderer panelRenderer;
    private Renderer sphereRenderer;

    void Start()
    {
        panelRenderer = GetComponent<Renderer>();
        if (targetSphere != null)
        {
            sphereRenderer = targetSphere.GetComponent<Renderer>();
        }
    }

    public void OnMouseDown()
    {
        MakeAction();
    }

    public void MakeAction()
    {
        // Select a random material from the color options
        int randomIndex = Random.Range(0, colorOptions.Length);
        Material chosenMaterial = colorOptions[randomIndex];

        // Change the flat side's color (optional, for visual feedback)
        panelRenderer.material = chosenMaterial;

        // Update the sphere's color and trigger an animation
        {
            sphereRenderer.material = chosenMaterial;

            // Add a small animation (e.g., scale effect)
            StartCoroutine(AnimateSphere());
        }
    }
    // Coroutine for scaling animation
    IEnumerator AnimateSphere()
    {
        Vector3 originalScale = targetSphere.transform.localScale;
        targetSphere.transform.localScale = originalScale * 1.2f;
        yield return new WaitForSeconds(0.2f);
        targetSphere.transform.localScale = originalScale;
    }
}