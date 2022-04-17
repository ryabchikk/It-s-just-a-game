using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensivity;
    [SerializeField] private Transform playerBody;
    
    private float xRotation = 0f;
    private bool _isActive;
    
    void Start()
    {
        _isActive = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!_isActive)
            return;
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void Activate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}
