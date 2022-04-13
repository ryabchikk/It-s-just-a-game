using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent<GameObject> action;
    
    public void Interact(PlayerInteract interactingObject)
    {
        action?.Invoke(interactingObject.Player);
    }
}
