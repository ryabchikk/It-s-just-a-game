using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private float jumpForce;
    [SerializeField] private PlayerInteract interact;

    private bool _isOnGround;

    private void Update()
    {
        var translationVector = Vector3.zero;
        
        if(Input.GetKey(Controls.Forward))
            translationVector += Vector3.forward;
        else if(Input.GetKey(Controls.Back))
            translationVector += Vector3.back;
        
        if(Input.GetKey(Controls.Left))
            translationVector += Vector3.left;
        else if(Input.GetKey(Controls.Right))
            translationVector += Vector3.right;

        if (Input.GetKeyDown(Controls.Interact))
            interact.Interact();
        
        transform.Translate(translationVector * (Time.deltaTime * speed));
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(Controls.Jump) && _isOnGround)
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            _isOnGround = true;
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            _isOnGround = false;
    }
}
