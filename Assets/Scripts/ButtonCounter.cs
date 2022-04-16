using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonCounter : MonoBehaviour
{
    [SerializeField] private int requestedCount;
    [SerializeField] private UnityEvent onRequiredCount;
    [SerializeField] private UnityEvent onDecreasedCount;
    private int _buttonCount;
    
    public void IncCount()
    {
        _buttonCount++;
        Debug.Log($"Current count: {_buttonCount}");
        if (_buttonCount >= requestedCount)
            onRequiredCount?.Invoke();
    }

    public void DecCount()
    {
        _buttonCount--;
        Debug.Log($"Current count: {_buttonCount}");
        if (_buttonCount == requestedCount - 1)
            onDecreasedCount?.Invoke();
    }
}
