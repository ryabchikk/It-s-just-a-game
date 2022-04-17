using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(14,10)] [SerializeField] string storyText;
    [SerializeField] public string[] Buttons;
    [SerializeField] public State[] nextStates;
    [SerializeField] public bool goodEnding;
    [SerializeField] public bool badEnding;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

}