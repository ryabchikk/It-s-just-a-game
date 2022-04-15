using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ground
{
    Floor,
    Ceiling,
    LeftWall,
    RightWall,
    FrontWall,
    BackWall
}

public class RoomRotater : MonoBehaviour
{
    [SerializeField] Transform player_transform;
    [SerializeField] CharacterController controller;
    [SerializeField] int time;
    [SerializeField] bool isLocked;
    private Vector3 _rotation_vector;
    
    public static Vector3 WorldRotationVector(Ground ground) 
    {
        Vector3 vector = new Vector3(0, 0, 0);
        switch (ground)
        {
            case Ground.Floor: return new Vector3(0, 0, 0); 
            case Ground.Ceiling: return new Vector3(0, 0, 180);
            case Ground.LeftWall: return new Vector3(90, 0, 0);
            case Ground.RightWall: return new Vector3(-90, 0, 0);
            case Ground.FrontWall: return new Vector3(0, 0, 90);
            case Ground.BackWall: return new Vector3(0, 0, -90);
                default: return vector;
        }
    }
    
    void Start()
    {
        if (isLocked)
            StartCoroutine(RotateByTime());
        else 
            StartCoroutine(GiveControl());
        
    }
    public IEnumerator Rotate() 
    {
        _rotation_vector = new Vector3(0, 0, 1);
        for (int i = 0; i < 90; i++)
        {
            yield return null;
            transform.Rotate(_rotation_vector);
        }

        Debug.Log("Room rotation: " + transform.rotation.eulerAngles);
    }
    IEnumerator GiveControl()
    {
        _rotation_vector = new Vector3(0, 0, 0);
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(Controls.RotateRoom));
            StartCoroutine(Rotate());

            //Vector3 new_gravity = Quaternion.Euler(WorldRotationVector((Ground)arr[index])) * Physics.gravity;
            //Vector3 new_gravity = Quaternion.AngleAxis(-90, this.transform.up) * Physics.gravity;
            //Physics.gravity = new_gravity;
            yield return new WaitForSeconds(2);
        }
    }
    IEnumerator RotateByTime()
    {
        _rotation_vector = new Vector3(0, 0, 0);
        while (true)
        {
            yield return new WaitForSeconds(time);
            StartCoroutine(Rotate());
            //Vector3 new_gravity = Quaternion.Euler(WorldRotationVector((Ground)arr[index])) * Physics.gravity;
            //Vector3 new_gravity = Quaternion.AngleAxis(-90, this.transform.up) * Physics.gravity;
            //Physics.gravity = new_gravity;
        }
    }
}
