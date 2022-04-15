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
    private bool _isOnGround;
    private CharacterController _characterController;
    private float _velocity;
    private float gravity = -9.81f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        //CharacterJump();
        CharacterMove();
        if(Input.GetKeyDown(Controls.Interact))
            interact.Interact();
    }
    private void CharacterMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * speed;
        _moveVector.z = Input.GetAxis("Vertical") * speed;
        _moveVector.y = VerticalVelocity();// * Time.deltaTime;
        Vector3 move = transform.right * _moveVector.x + transform.forward * _moveVector.z + _moveVector.y * transform.up;
        move *= Time.deltaTime;
        //move = transform.TransformDirection(move);
        _characterController.Move(move);
    }
    private float VerticalVelocity() 
    {
        
        /*if (_velocity < 0 && _isOnGround) 
        {
            _velocity = -2f;
        }*/
        if (_isOnGround)
        {
            _velocity = -2f;
        }
        if (Input.GetKey(KeyCode.Space) && _isOnGround)
        {
            //_isOnGround = false;
            _velocity = Mathf.Sqrt(jumpPow * -2f * gravity);
        }
        _velocity += gravity * Time.deltaTime;
        return _velocity;
    }

    public void SetOnGround(bool value)
    {
        _isOnGround = value;
    }
}
