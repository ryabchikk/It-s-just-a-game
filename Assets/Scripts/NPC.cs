using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] DialogueScript dialogue;

    public void Interact(PlayerInteract interactingObject)
    {
        dialogue.StartDialogue();
    }
}
