using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private new Camera camera;
    private float _xRotation;
    private float _yRotation;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
 
        _yRotation += mouseX * Controls.MouseVertical;
        _xRotation -= mouseY * Controls.MouseHorizontal;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
 
        camera.transform.eulerAngles = new Vector3(_xRotation, _yRotation, 0);
        transform.eulerAngles = new Vector3(0, _yRotation, 0);
    }
}
