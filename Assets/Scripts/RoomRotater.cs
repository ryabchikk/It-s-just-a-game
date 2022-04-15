using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Down,
    Up,
    Left,
    Right,
    Front,
    Back
}

public class RoomRotater : MonoBehaviour
{
    [SerializeField] Transform player_transform;
    [SerializeField] CharacterController controller;
    [SerializeField] bool changeGravity = false;
    private Vector3 _rotation_vector;
    
    public static Vector3 WorldRotationVector(Direction ground) 
    {
        switch (ground)
        {
            case Direction.Down: return new Vector3(0, 0, 0); 
            case Direction.Up: return new Vector3(0, 0, 2);
            case Direction.Left: return new Vector3(-1, 0, 0);
            case Direction.Right: return new Vector3(1, 0, 0);
            case Direction.Front: return new Vector3(0, 0, 1);
            case Direction.Back: return new Vector3(0, 0, -1);
                default: return new Vector3(0, 0, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestCoroutine());
    }
    
    IEnumerator TestCoroutine()
    {
        var directions = new Direction[] { Direction.Front, Direction.Left, Direction.Left, Direction.Left, Direction.Front, Direction.Up };
        int index = 0;
        while (true)
        {
            var direction = directions[index];
            Debug.Log(direction);
            yield return new WaitUntil(() => Input.GetKeyDown(Controls.RotateRoom));

            _rotation_vector = WorldRotationVector(direction);

            for (int i = 0; i < 90; i++)
            {
                yield return null;
                transform.Rotate(_rotation_vector);
            }

            if (changeGravity)
            {
                Physics.gravity = transform.up * -9.8f;
            }

            yield return new WaitForSeconds(1);
            index = (index + 1) % directions.Length;
        }
     }
}
