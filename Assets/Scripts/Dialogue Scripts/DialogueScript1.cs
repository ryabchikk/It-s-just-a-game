using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueScript1 : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] NovelState startingState;
    [SerializeField] Text button1text;
    [SerializeField] Text endbuttontext;

    [SerializeField] GameObject button1;
    [SerializeField] GameObject endButton;

    [SerializeField] private GameObject[] sprites;

    [SerializeField] GameObject cube_name_box;
    [SerializeField] GameObject player_name_box;

    NovelState state;

	// Use this for initialization
	void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        cube_name_box.SetActive(false);
        player_name_box.SetActive(false);
        endButton.SetActive(false);
        SetScene();
	}
	
	// Update is called once per frame
    public void SetScene()
    {
        button1text.text = state.Buttons[0];
        if(state.cube_name_box)
        {
            cube_name_box.SetActive(true);
            player_name_box.SetActive(false);
        }
        else if(state.player_name_box)
        {
            cube_name_box.SetActive(false);
            player_name_box.SetActive(true);
        }
        else
        {
            cube_name_box.SetActive(false);
            player_name_box.SetActive(false);
        }
       var nextStates = state.GetNextStates();
       var sprite = state.GetSprite();
        if (sprite == 0)
        {
            sprites[0].SetActive(true);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);
            sprites[3].SetActive(false);
            sprites[4].SetActive(false);
        }
        else if (sprite == 1)
        {
            sprites[0].SetActive(false);
            sprites[1].SetActive(true);
            sprites[2].SetActive(false);
            sprites[3].SetActive(false);
            sprites[4].SetActive(false);
        }
        else if (sprite == 2)
        {
            sprites[0].SetActive(false);
            sprites[1].SetActive(false);
            sprites[2].SetActive(true);
            sprites[3].SetActive(false);
            sprites[4].SetActive(false);
        }
        else if (sprite == 3)
        {
            sprites[0].SetActive(false);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);
            sprites[3].SetActive(true);
            sprites[4].SetActive(false);
        }
        else if (sprite == 4)
        {
            sprites[0].SetActive(false);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);
            sprites[3].SetActive(false);
            sprites[4].SetActive(true);
        }
        if(state.fin)
        {
            button1.SetActive(false);
            endButton.SetActive(true);
            endbuttontext.text = state.Buttons[0];
        }
    }

    public void EndNovel()
    {
         SceneManager.LoadScene(0);
    }
    public void FirstChoice()
    { 
        var nextStates = state.GetNextStates();
        state = nextStates[0];
        textComponent.text = state.GetStateStory();
        SetScene();
    }


}
