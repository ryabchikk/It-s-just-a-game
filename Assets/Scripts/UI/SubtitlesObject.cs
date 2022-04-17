﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class SubtitlesObject : MonoBehaviour
{
    [SerializeField] private Animator textAnimator;
    [SerializeField] private Animator panelAnimator;
    [SerializeField] private Text text;
    private readonly Queue<string> _notifications = new Queue<string>();
    private bool _appearing;

    private void Awake()
    {
        Subtitles.CreateNotificator(this);
        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
        if (_notifications.Count == 0 || _appearing)
            return;
        
        StartCoroutine(Appear());
        
    }

    public void Notify(string n)
    {
        if (_notifications.Contains(n))
        {
            return;
        }
        
        _notifications.Enqueue(n);
    }

    private IEnumerator Appear()
    {
        _appearing = true;
        panelAnimator.enabled = true;
        while (_notifications.Count != 0)
        {
            textAnimator.enabled = true;
            text.text = _notifications.Peek();
            yield return new WaitForSeconds(2.5f);
            _notifications.Dequeue();
            textAnimator.enabled = false;
        }
        panelAnimator.enabled =false;
        _appearing = false;
    }
}