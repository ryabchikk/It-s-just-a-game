using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker2D : MonoBehaviour
{
    [SerializeField] Movement2D player;
    [SerializeField] Collider playerCollider;

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
            return;
        if (other != null)
        {
            player.SetOnGround(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger)
            return;
        if (other != null && other != playerCollider)
        {
            player.SetOnGround(true);
        }
    }
}
