using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private UnityEvent onDialogueFinished;

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] GameObject background;
    [SerializeField] Text button1text;
    [SerializeField] Text button2text;
    [SerializeField] Text button3text;

    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;

    [SerializeField] MouseLook mouseLook;
    State state;

	// Use this for initialization
	void Start()
    {
        background.SetActive(false);
	}

    public void StartDialogue()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        state = startingState;
        textComponent.text = state.GetStateStory();
        background.SetActive(true);
        mouseLook.Deactivate();
        SetScene();
    }

    public void StopDialogue()
    {
        background.SetActive(false);
        mouseLook.Activate();
        onDialogueFinished?.Invoke();
    }

    public void SetScene()
    {
        var nextStates = state.GetNextStates();
        if(nextStates.Length == 1)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(true);
            button3text.text = state.Buttons[0];
        }
        if(nextStates.Length == 2)
        {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(false);
            button1text.text = state.Buttons[0];
            button2text.text = state.Buttons[1];
        }
        
    }
    public void FirstChoice()
    { 
        if(state.final)
        {
            StopDialogue();
        }
        var nextStates = state.GetNextStates();
        state = nextStates[0];
        textComponent.text = state.GetStateStory();
        Debug.Log("Pressed");
        SetScene();
    }
    public void SecondChoice()
    {
        if(state.final)
        {
            StopDialogue();
        }
        var nextStates = state.GetNextStates();
        state = nextStates[1];
        textComponent.text = state.GetStateStory();
        SetScene();
    }

}
