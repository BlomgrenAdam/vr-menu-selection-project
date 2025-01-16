using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuInteraction : MonoBehaviour
{
    public GameObject colorMenu;
    public GameObject materialMenu;
    public GameObject sizeMenu;
    public GameObject textMenu;
    public GameObject patternMenu;
    public GameObject distortedScaleMenu;

    private Renderer objRenderer;
    private Color originalColor;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
        colorMenu.SetActive(false); // Se till att submenyn är inaktiv vid start
        materialMenu.SetActive(false); // Se till att materialmenyn är inaktiv vid start
        sizeMenu.SetActive(false); // Se till att storleksmenyn är inaktiv vid start
        textMenu.SetActive(false); // Se till att textmenyn är inaktiv vid start
        patternMenu.SetActive(false); // Se till att mönstermenyn är inaktiv vid start
        distortedScaleMenu.SetActive(false); // Se till att förvrängda skala-menyn är inaktiv vid start
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        objRenderer.material.color = Color.yellow; // Highlight-färg
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        objRenderer.material.color = originalColor; // Återställ till originalfärgen
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ChooseColor");
        // Växla visibilitet för färgmenyn
        colorMenu.SetActive(!colorMenu.activeSelf);
    }

    public void OnMaterialMenuActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ChooseMaterial");
        // Visa materialmenyn och dölja andra menyer
        materialMenu.SetActive(!materialMenu.activeSelf);
        colorMenu.SetActive(false);
        sizeMenu.SetActive(false);
        textMenu.SetActive(false);
        patternMenu.SetActive(false);
        distortedScaleMenu.SetActive(false);
    }

    public void OnSizeMenuActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ChooseSize");
        // Visa storleksmenyn och dölja andra menyer
        sizeMenu.SetActive(!sizeMenu.activeSelf);
        colorMenu.SetActive(false);
        materialMenu.SetActive(false);
        textMenu.SetActive(false);
        patternMenu.SetActive(false);
        distortedScaleMenu.SetActive(false);
    }

    public void OnTextMenuActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ChooseText");
        // Visa textmenyn och dölja andra menyer
        textMenu.SetActive(!textMenu.activeSelf);
        colorMenu.SetActive(false);
        materialMenu.SetActive(false);
        sizeMenu.SetActive(false);
        patternMenu.SetActive(false);
        distortedScaleMenu.SetActive(false);
    }

    public void OnPatternMenuActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ChoosePattern");
        // Visa mönstermenyn och dölja andra menyer
        patternMenu.SetActive(!patternMenu.activeSelf);
        colorMenu.SetActive(false);
        materialMenu.SetActive(false);
        sizeMenu.SetActive(false);
        textMenu.SetActive(false);
        distortedScaleMenu.SetActive(false);
    }

    public void OnDistortedScaleMenuActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ChooseDistortedScale");
        // Visa förvrängda skala-menyn och dölja andra menyer
        distortedScaleMenu.SetActive(!distortedScaleMenu.activeSelf);
        colorMenu.SetActive(false);
        materialMenu.SetActive(false);
        sizeMenu.SetActive(false);
        textMenu.SetActive(false);
        patternMenu.SetActive(false);
    }
}
