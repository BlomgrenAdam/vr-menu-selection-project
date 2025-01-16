using UnityEngine;

public class HoverInteraction : MonoBehaviour
{
    public Color hoverColor = Color.red;  // Color when the object is gazed at
    private Color originalColor;          // Original color of the object
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component to change color
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;  // Save the original color
    }

    void Update()
    {
        // Cast a ray from the camera
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0)); // Cast a ray from the center of the screen (gaze point)
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hits this object
            if (hit.collider.gameObject == gameObject)
            {
                // Change the color when the object is gazed at
                objectRenderer.material.color = hoverColor;
            }
            else
            {
                // Revert to the original color when the gaze leaves the object
                objectRenderer.material.color = originalColor;
            }
        }
        else
        {
            // Revert to the original color if the ray hits nothing
            objectRenderer.material.color = originalColor;
        }
    }
}