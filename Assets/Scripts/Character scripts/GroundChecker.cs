using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] CharacterMechanics player;
    [SerializeField] Collider playerCollider;

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            Debug.Log("not on ground!");
            player.SetOnGround(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null && other != playerCollider)
        {
            Debug.Log("on ground");
            Debug.Log(other.gameObject.name);
            player.SetOnGround(true);
        }
    }
}
