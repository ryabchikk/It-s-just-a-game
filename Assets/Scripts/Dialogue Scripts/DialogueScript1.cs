using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript1 : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] NovelState startingState;
    [SerializeField] Text button1text;
    [SerializeField] Text button2text;

    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;

    [SerializeField] private GameObject[] sprites;


    NovelState state;

	// Use this for initialization
	void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        SetScene();
	}
	
	// Update is called once per frame
    public void SetScene()
    {
       var nextStates = state.GetNextStates();
       var sprite = state.GetSprite();
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
        if (sprite == 0)
        {
            sprites[0].SetActive(true);
            sprites[1].SetActive(false);
        }
        else if (sprite == 1)
        {
            sprites[0].SetActive(false);
            sprites[1].SetActive(true);
        }
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
