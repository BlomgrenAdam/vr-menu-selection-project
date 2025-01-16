using UnityEngine;

public class MainButtonScript : MonoBehaviour
{
    public GameObject[] coloredCylinders; // Array för de tre färgade cylindrarna

    void OnMouseDown()
    {
        // Aktivera de färgade cylindrarna
        foreach (GameObject cylinder in coloredCylinders)
        {
            cylinder.SetActive(true);
        }
    }
}
