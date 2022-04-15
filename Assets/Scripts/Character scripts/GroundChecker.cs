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
            player.SetOnGround(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null && other != playerCollider)
        {
            player.SetOnGround(true);
        }
    }
}
