using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TextSelection : MonoBehaviour
{
    public Material material; // Materialet f�r denna knapp
    public GameObject targetObject; // Objektet som ska �ndra material

    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        objRenderer.material = material; // St�ll in materialet p� knappen
    }

    public void OnActivated(ActivateEventArgs args)
    {
        Debug.Log("Activated on MaterialButton: " + material.name);
        Renderer targetRenderer = targetObject.GetComponent<Renderer>();
        targetRenderer.material = material; // �ndra objektets material
    }
}





/*using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro; // Om du anv�nder TextMeshPro f�r text

public class TextSelection : MonoBehaviour
{
    public string text; // Texten f�r denna knapp
    public GameObject targetObject; // Objektet som ska visa texten
    public GameObject textPrefab; // Prefab f�r TextMeshPro-objektet

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
        textObject.name = "TextMeshPro - " + text; // F�r att identifiera textobjekt
    }
}*/
