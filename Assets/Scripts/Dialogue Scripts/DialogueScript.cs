using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] GameObject background;
    [SerializeField] Text button1text;
    [SerializeField] Text button2text;

    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;

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
    }

    public void SetScene()
    {
        var nextStates = state.GetNextStates();
        if(nextStates.Length == 1)
        {
            button2.SetActive(false);
            button1text.text = state.Buttons[0];
        }
        if(nextStates.Length == 2)
        {
            button2.SetActive(true);
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
