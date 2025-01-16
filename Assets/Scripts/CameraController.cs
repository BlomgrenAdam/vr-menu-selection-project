using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Adjust this for faster/slower rotation
    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust the vertical rotation (up and down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents flipping over

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}