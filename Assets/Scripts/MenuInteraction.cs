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
        colorMenu.SetActive(false); // Se till att submenyn �r inaktiv vid start
        materialMenu.SetActive(false); // Se till att materialmenyn �r inaktiv vid start
        sizeMenu.SetActive(false); // Se till att storleksmenyn �r inaktiv vid start
        textMenu.SetActive(false); // Se till att textmenyn �r inaktiv vid start
        patternMenu.SetActive(false); // Se till att m�nstermenyn �r inaktiv vid start
        distortedScaleMenu.SetActive(false); // Se till att f�rvr�ngda skala-menyn �r inaktiv vid start
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        objRenderer.material.color = Color.yellow; // Highlight-f�rg
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        objRenderer.material.color = originalColor; // �terst�ll till originalf�rgen
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ChooseColor");
        // V�xla visibilitet f�r f�rgmenyn
        colorMenu.SetActive(!colorMenu.activeSelf);
    }

    public void OnMaterialMenuActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on ChooseMaterial");
        // Visa materialmenyn och d�lja andra menyer
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
        // Visa storleksmenyn och d�lja andra menyer
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
        // Visa textmenyn och d�lja andra menyer
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
        // Visa m�nstermenyn och d�lja andra menyer
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
        // Visa f�rvr�ngda skala-menyn och d�lja andra menyer
        distortedScaleMenu.SetActive(!distortedScaleMenu.activeSelf);
        colorMenu.SetActive(false);
        materialMenu.SetActive(false);
        sizeMenu.SetActive(false);
        textMenu.SetActive(false);
        patternMenu.SetActive(false);
    }
}
