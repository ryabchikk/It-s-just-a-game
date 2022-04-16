using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(CharacterController))]
public class DeadFromThorn : MonoBehaviour
{
    [SerializeField] private Transform obj;

    private CharacterController _controller;
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "thorn")
        {

            _controller.enabled=false;
            transform.position = obj.position;
            _controller.enabled = true;
            Debug.Log("trigger");
        }
    }
}
