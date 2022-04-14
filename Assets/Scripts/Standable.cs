using UnityEngine;
using UnityEngine.Events;

public class Standable : MonoBehaviour
{
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onUnpressed;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        onPressed?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onUnpressed?.Invoke();
    }
}
