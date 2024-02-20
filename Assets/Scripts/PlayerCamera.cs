using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] float mouseSensitivity = 110;

    public Transform playerBody;

    float xRotation = 0f;

    PlayerMovment playerMovment;
    PermanentScript permanentScript;
    Menuhandler pauseScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMovment = FindAnyObjectByType<PlayerMovment>();
        permanentScript = FindAnyObjectByType<PermanentScript>();
        pauseScript = FindAnyObjectByType<Menuhandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseScript.MenuIsActive)
        {
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        if (permanentScript.noMoreMainMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= MouseY;
        if (playerMovment.isGrounded)
        {
            xRotation = Mathf.Clamp(xRotation, -90f, 90);
        }

        transform.localRotation = (UnityEngine.Quaternion.Euler(xRotation, 0f, 0f));
        playerBody.Rotate(UnityEngine.Vector3.up * MouseX);
    }
}
