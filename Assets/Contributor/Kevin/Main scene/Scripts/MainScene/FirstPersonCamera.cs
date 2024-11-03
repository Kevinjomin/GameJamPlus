using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Mouse sensitivity

    private float xRotation = 0f;
    private float yRotation = 0f;
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // Invert Y rotation
        xRotation = Mathf.Clamp(xRotation, -70f, 70f); // Clamp the x rotation to prevent flipping

        yRotation += mouseX;

        // Apply the camera rotation
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); // Use local rotation
    }
}
