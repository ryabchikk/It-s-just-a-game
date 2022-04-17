using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private BoxCollider triggerExit;
    private bool _opened;
    public void Open()
    {
        if (!_opened)
        {
            _opened = true;
            triggerExit.enabled = true;
            Debug.Log("Door is opened");
        }
    }

    public void Close()
    {
        Debug.Log("Closing the door...");
        if (_opened)
        {
            _opened = false;
            triggerExit.enabled = false;
            Debug.Log("Door is closed");
        }
    }
}
