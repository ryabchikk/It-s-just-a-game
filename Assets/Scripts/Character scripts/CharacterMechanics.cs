using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMechanics : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPow;
    [SerializeField] private PlayerInteract interact;
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
        CharacterMove();
        if(Input.GetKeyDown(Controls.Interact))
            interact.Interact();
    }
    private void CharacterMove()
    {
        Vector3 _moveVector;
        _moveVector = Vector3.zero;
        if (Input.GetKey(Controls.Forward))
            _moveVector += transform.forward * speed;
        else if (Input.GetKey(Controls.Back))
            _moveVector -= transform.forward * speed;

        if (Input.GetKey(Controls.Left))
            _moveVector -= transform.right * speed;
        else if (Input.GetKey(Controls.Right))
            _moveVector += transform.right*speed;

        _moveVector += VerticalVelocity() * transform.up;
        _characterController.Move(_moveVector*Time.deltaTime);
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
