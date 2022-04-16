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


    State state;

	// Use this for initialization
	void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        background.SetActive(true);
        SetScene();
	}
	
	// Update is called once per frame
    public void SetScene()
    {
        button1text.text = state.Buttons[0];
        button2text.text = state.Buttons[1];
    }
    public void FirstChoice()
    { 
        var nextStates = state.GetNextStates();
        state = nextStates[0];
        textComponent.text = state.GetStateStory();
        Debug.Log("Pressed");
        SetScene();
    }
    public void SecondChoice()
    {
        var nextStates = state.GetNextStates();
        state = nextStates[1];
        textComponent.text = state.GetStateStory();
        SetScene();
    }

}
