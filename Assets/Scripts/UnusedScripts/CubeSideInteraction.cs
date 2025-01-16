using UnityEngine;

public class CubeSideInteraction : MonoBehaviour
{
    public string action;
    public GameObject targetMenu;

    private Renderer sideRenderer;
    private Color originalColor;

    void Start()
    {
        sideRenderer = GetComponent<Renderer>();
        originalColor = sideRenderer.material.color;
    }

    void OnMouseEnter()
    {
        sideRenderer.material.color = Color.yellow; // Highlight color
    }

    void OnMouseExit()
    {
        sideRenderer.material.color = originalColor; // Revert to original color
    }

    void OnMouseDown()
    {
        PerformAction();
    }

    public void PerformAction()
    {
        if (action == "ColorMenu" && targetMenu != null)
        {
            targetMenu.SetActive(true);
        }
        else if (action == "SubMenu" && targetMenu != null)
        {
            targetMenu.SetActive(true);
        }
        else
        {
            Debug.Log("Action not assigned or targetMenu is null!");
        }
    }
}
