using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NovelState")]
public class NovelState : ScriptableObject
{
    [TextArea(14,10)] [SerializeField] string storyText;
    [SerializeField] public string[] Buttons;
    [SerializeField] NovelState[] nextStates;
    [SerializeField] int sprite;

    public string GetStateStory()
    {
        return storyText;
    }

    public int GetSprite()
    {
        return sprite;
    }

    public NovelState[] GetNextStates()
    {
        return nextStates;
    }
}
