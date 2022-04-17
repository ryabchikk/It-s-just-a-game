using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObserver : MonoBehaviour
{
    [SerializeField] Pickable[] boxes;
    private BoxBehaviour boxBehaviour;

    public void ActivateNPC()
    {
        Debug.Log("Activating npc");
        Pickable box = null;
        foreach (var _box in boxes)
        {
            if (!_box.isPlaced)
            {
                box = _box;
                break;
            }
        }
        //Debug.Log(box.name);
        boxBehaviour = box.GetComponent<BoxBehaviour>();
        boxBehaviour.SetNPC();
    }

    public void DeactivateNPC()
    {
        boxBehaviour.SetPickable();
    }
}
