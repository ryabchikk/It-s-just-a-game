using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonCounter : MonoBehaviour
{
    [SerializeField] int requestedCount = 3;
    [SerializeField] UnityEvent onRequiredCount;
    [SerializeField] UnityEvent onDecreasedCount;
    public int ButtonCount { get; private set; }
    
    public void IncCount()
    {
        ButtonCount++;
        Debug.Log($"Current count: {ButtonCount}");
        if (ButtonCount >= requestedCount)
            onRequiredCount?.Invoke();
    }

    public void DecCount()
    {
        ButtonCount--;
        Debug.Log($"Current count: {ButtonCount}");
        if (ButtonCount == requestedCount - 1)
            onDecreasedCount?.Invoke();
    }
}
