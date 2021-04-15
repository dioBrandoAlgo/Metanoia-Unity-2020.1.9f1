using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float mouseSense = 100f;

    public Transform player;

    public float XRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense;

        XRot -= mouseY;
        XRot = Mathf.Clamp(XRot, -90f, 45f);

        transform.localRotation = Quaternion.Euler(XRot, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        

    }
}
