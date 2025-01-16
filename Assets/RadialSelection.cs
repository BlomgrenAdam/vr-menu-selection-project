using UnityEngine;
using UnityEngine.UI;

public class RadialSelection : MonoBehaviour
{
    [Range(2, 10)]
    public int numberOfRadialPart;
    public GameObject radialPartPrefab;
    public Transform RadialPartCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRadialPart()
    {
        for (int i = 0; i < numberOfRadialPart; i++)
        { float angle = i * 360 / numberOfRadialPart;
            Vector3 radialPartEulerAngle = new Vector3(0, 0, angle);

            GameObject spawnedRadialPart = Instantiate(radialPartPrefab, RadialPartCanvas);
            spawnedRadialPart.transform.position = RadialPartCanvas.position;
            spawnedRadialPart.transform.localEulerAngles = radialPartEulerAngle;

            spawnedRadialPart.GetComponent<Image>().fillAmount = 1 / (float)numberOfRadialPart;
        }
}
}
