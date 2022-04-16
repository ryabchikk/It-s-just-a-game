using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObserver : MonoBehaviour
{
    [SerializeField] Pickable[] boxes;

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
        BoxBehaviour behaviour = box.GetComponent<BoxBehaviour>();
        behaviour.SetNPC();
    }
}
