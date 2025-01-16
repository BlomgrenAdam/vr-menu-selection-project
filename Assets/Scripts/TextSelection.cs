using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TextSelection : MonoBehaviour
{
    public Material material; // Materialet för denna knapp
    public GameObject targetObject; // Objektet som ska ändra material

    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        objRenderer.material = material; // Ställ in materialet på knappen
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on MaterialButton: " + material.name);
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material = material; // Ändra objektets material
    }
}





/*using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro; // Om du använder TextMeshPro för text

public class TextSelection : MonoBehaviour
{
    public string text; // Texten för denna knapp
    public GameObject targetObject; // Objektet som ska visa texten
    public GameObject textPrefab; // Prefab för TextMeshPro-objektet

    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on TextButton: " + text);
        // Radera tidigare textobjekt om de finns
        foreach (Transform child in targetObject.transform)
        {
            if (child.gameObject.name.Contains("TextMeshPro"))
            {
                Destroy(child.gameObject);
            }
        }
        // Skapa nytt textobjekt
        GameObject textObject = Instantiate(textPrefab, targetObject.transform);
        textObject.GetComponent<TMP_Text>().text = text;
        textObject.name = "TextMeshPro - " + text; // För att identifiera textobjekt
    }
}*/
