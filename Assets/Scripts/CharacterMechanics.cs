using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPow;

    private Vector3 moveVector;
    private float gravForce;
    private CharacterController ch_controller;
    private Vector3 velocity;
    private float gravity = -9.81f;
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CharacterMove();
    }
    private void CharacterMove()
    {
        if (ch_controller.isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
        
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.z = Input.GetAxis("Vertical") * speed;
        
        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.z;
        
        ch_controller.Move(move * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)&& ch_controller.isGrounded) 
        {
            velocity.y = Mathf.Sqrt(3f * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        
        ch_controller.Move(velocity * Time.deltaTime);
    }
}
