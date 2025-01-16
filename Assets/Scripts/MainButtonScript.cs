using UnityEngine;

public class MainButtonScript : MonoBehaviour
{
    public GameObject[] coloredCylinders; // Array f�r de tre f�rgade cylindrarna

    void OnMouseDown()
    {
        // Aktivera de f�rgade cylindrarna
        foreach (GameObject cylinder in coloredCylinders)
        {
            cylinder.SetActive(true);
        }
    }
}
