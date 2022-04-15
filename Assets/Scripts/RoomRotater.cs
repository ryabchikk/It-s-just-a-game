using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRotater : MonoBehaviour
{
    [SerializeField] Transform player_transform;
    [SerializeField] CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(4);

        var rotation_vector = new Vector3(0, 0, -90);
        rotation_vector = rotation_vector - player_transform.rotation.eulerAngles;
        player_transform.Rotate(rotation_vector);
        Vector3 new_gravity = new Vector3(-9.8f, 0, 0);
        Physics.gravity = new_gravity;
        //controller.transform.Rotate(rotation_vector);
     }
}
