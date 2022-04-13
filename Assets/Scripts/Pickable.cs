using System;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    private bool _isPickedUp;

    private void Start()
    {
        Debug.Log(transform.parent is null);
    }

    public void Interact(GameObject interactingObject)
    {
        if(_isPickedUp)
        {
            transform.SetParent(interactingObject.transform);
            _isPickedUp = true;
        }
        else
        {
            transform.SetParent(null);
            _isPickedUp = false;
        }
    }
}
