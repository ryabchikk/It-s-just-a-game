using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] int freezeDelay = 1;

    private bool _isPickedUp;
    private float _distance;
    private Rigidbody _rigidbody;
    private PlayerInteract _interactingObject;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(_isPickedUp)
            _rigidbody.velocity = 10f * (_interactingObject.InteractDistancePosition - transform.position);
    }

    public void Interact(PlayerInteract interactingObject)
    {
        if(!_isPickedUp)
        {
            _distance = interactingObject.InteractDistance;
            _interactingObject = interactingObject;
            _isPickedUp = true;
            _rigidbody.freezeRotation = true;
        }
        else
        {
            _isPickedUp = false;
            _rigidbody.freezeRotation = false;
        }
    }

    public bool IsPickedUp
    {
        get { return _isPickedUp; }
    }

    public IEnumerator FreezePhysics()
    {
        yield return new WaitForSeconds(freezeDelay); // For falling to finish

        _rigidbody.isKinematic = true;
    }
}
