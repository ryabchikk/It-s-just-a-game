using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _opened;
    public void Open()
    {
        if (!_opened)
        {
            _opened = true;
            Debug.Log("Door is opened");
        }
    }

    public void Close()
    {
        if (_opened)
        {
            _opened = false;
            Debug.Log("Door is closed");
        }
    }
}