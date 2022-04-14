using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject Player => player;
    public float InteractDistance => interactDistance;
    public Vector3 InteractDistancePosition => transform.position + transform.forward * interactDistance;
    [SerializeField] private float interactDistance;
    [SerializeField] private GameObject player;
    [SerializeField] private new Transform camera;
    private IInteractable _holdedObject;
    
    public void Interact()
    {
        var mask = 1 << 6;
        Debug.DrawLine(transform.position, transform.forward * interactDistance, Color.red);
        if (_holdedObject is Pickable _)
        {
            _holdedObject.Interact(this);
            _holdedObject = null;
            return;
        }
        if (!Physics.Raycast(transform.position, camera.forward, out var hit, interactDistance, mask)) 
            return;
        
        var interactable = hit.collider.gameObject.GetComponent<IInteractable>();
        _holdedObject = interactable;

        interactable?.Interact(this);
    }
}
