using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{
    public static Subtitles Instance;
    
    [SerializeField] private Text text;

    private void Awake()
    {
        Instance = this;
    }

    public void Show(string textToShow)
    {
        text.text = textToShow;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
