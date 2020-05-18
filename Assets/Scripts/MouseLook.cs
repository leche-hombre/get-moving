using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ResetRotation();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        // horizontal
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

        // vertical
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ResetRotation()
    {
        // TODO: Fix this so rotation starts at a 0,0 pos
        Quaternion startingRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f));
        transform.localRotation = startingRotation;
    }
}
