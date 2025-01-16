using UnityEngine;
using UnityEngine.Events;

public class CubeFaceController : MonoBehaviour
{
    public UnityEvent onActivate;
    public GameObject menuToActivate; // Menyn som ska aktiveras
    public GameObject[] otherMenusToDeactivate; // Andra menyer som ska inaktiveras

    private void Start()
    {
        if (onActivate == null)
        {
            onActivate = new UnityEvent();
        }
    }

    public void Activate()
    {
        onActivate.Invoke();

        // Aktivera den specifika menyn
        if (menuToActivate != null)
        {
            menuToActivate.SetActive(true);
        }

        // Inaktivera andra menyer
        foreach (var menu in otherMenusToDeactivate)
        {
            if (menu != null)
            {
                menu.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        Activate();
    }
}