using UnityEngine;
using UnityEngine.Events;

public class Triggerable : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;
    [SerializeField] private UnityEvent exitTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("triggered");
            onTrigger?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        exitTrigger?.Invoke();
    }
}
