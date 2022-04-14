using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMechanics : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPow;
    [SerializeField] private PlayerInteract interact;
    
    private Vector3 _moveVector;
    private float _gravForce;
    private CharacterController _characterController;
    private Vector3 _velocity;
    private float gravity = -9.81f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        CharacterJump();
        CharacterMove();
        if(Input.GetKeyDown(Controls.Interact))
            interact.Interact();
    }
    private void CharacterMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * speed;
        _moveVector.z = Input.GetAxis("Vertical") * speed;
        Vector3 move = transform.right * _moveVector.x + transform.forward * _moveVector.z;
        _characterController.Move(move * Time.deltaTime);
    }
    private void CharacterJump() 
    {
        if (_velocity.y < 0 && _characterController.isGrounded) 
        {
            _velocity.y = -2f;
        }
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpPow * -2f * gravity);
        }
        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
