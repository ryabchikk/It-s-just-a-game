using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Transform player;

    public void MoveToPoint()
    {
        transform.SetParent(null);
        transform.position = point.position;
    }

    public void MoveToPlayer()
    {
        transform.position = player.position;
        transform.SetParent(player);
    }
}
