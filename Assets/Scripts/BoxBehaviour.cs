using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour, IInteractable
{
    private Pickable _pickable;
    private NPC _npc;
    private bool _isNPC;
    // Start is called before the first frame update
    void Start()
    {
        _isNPC = false;
        _pickable = GetComponent<Pickable>();
        _npc = GetComponent<NPC>();
        if (_npc == null || _pickable == null)
            Debug.Log("No npc script or pickable script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(PlayerInteract playerInteract)
    {
        //Debug.Log("Box behaviour Interact");
        if (_isNPC)
        {
            _npc.Interact(playerInteract);
        }
        else
        {
            _pickable.Interact(playerInteract);
        }
    }

    public void SetNPC()
    {
        _isNPC = true;
    }

    public void SetPickable()
    {
        _isNPC = false;
    }
}
