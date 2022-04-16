using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFromThorn : MonoBehaviour
{
    [SerializeField] private Transform obj;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            other.transform.Translate(10,0,0);
            Debug.Log("trigger");
        }
    }
}
