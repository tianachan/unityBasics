using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform Breadstick;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor stays in the middle of the screen rather than going outside of the window
        //CursorLockMode Cursor.lockState {get, set};
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Multiply by Time.deltaTime so frame rate doesn't affect
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate whole body on y axis
        // Vector3.up is shorthand for Vector3(0, 1, 0)
        Breadstick.Rotate(Vector3.up * mouseX);

        // Rotate camera to look up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Quaternions used for rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
