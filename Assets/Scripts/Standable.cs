using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Standable : MonoBehaviour
{
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onUnpressed;
    [SerializeField] private bool boxFreezes;

    private GameObject _parent;
    private Collider _enteredCollider;
    private Pickable _enteredPickable;
    private bool _pressed;

    private void Start()
    {
        _pressed = false;
        _enteredCollider = null;
        _enteredPickable = null;
        _parent = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Pickable pickable = other.GetComponent<Pickable>();
        if (pickable == null || rb == null || _pressed)
        {
            //Debug.Log("Not pickable!");
            return;
        }    
        if (other.CompareTag(_parent.tag))
        {
            _enteredCollider = other;
            _enteredPickable = pickable;
            //StartCoroutine(WaitPlayerToPlace(pickable));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_pressed)
            return;
        if (other != _enteredCollider || _enteredPickable == null)
            return;
        //if (!_enteredPickable.IsPickedUp)
        {
            _pressed = true;
            _enteredPickable.isPlaced = true;
            onPressed?.Invoke();
            if (boxFreezes)
                StartCoroutine(_enteredPickable.FreezePhysics());
        }
    }

    /*public IEnumerator WaitPlayerToPlace(Pickable pickable) 
    {
        yield return new WaitUntil(() => !pickable.IsPickedUp);
        
        _pressed = true;
        
        onPressed?.Invoke();
        if (boxFreezes)
            StartCoroutine(pickable.FreezePhysics());
    }*/

    // Not sure it is going to happen
    private void OnTriggerExit(Collider other)
    {
        if (boxFreezes || !_pressed)
            return;
        _pressed = false;
        if (other == _enteredCollider && _enteredPickable != null)
            _enteredPickable.isPlaced = false;
        onUnpressed?.Invoke();
    }
}
