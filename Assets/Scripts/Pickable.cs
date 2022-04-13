using System;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    private bool _isPickedUp;
    private float _distance;

    private void Update()
    {
        if(_isPickedUp)
            transform.localPosition = Vector3.forward * _distance;
    }

    public void Interact(PlayerInteract interactingObject)
    {
        if(!_isPickedUp)
        {
            transform.SetParent(interactingObject.transform);
            _distance = interactingObject.InteractDistance;
            _isPickedUp = true;
        }
        else
        {
            transform.SetParent(null);
            _isPickedUp = false;
        }
    }
}
