using UnityEngine;

public class RadialMenuController : MonoBehaviour
{
    public GameObject subMenu; // Tilldela undermenyn via Inspector.

    public void ToggleSubMenu()
    {
        // V�xla undermenyns aktiveringsstatus.
        if (subMenu != null)
        {
            subMenu.SetActive(!subMenu.activeSelf);
        }
    }
}
