using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Utility : MonoBehaviour
{
    [SerializeField] string[] message;
    public void ActivateSubtitles()
    {
        for (int i = 0; i < message.Length; i++) 
        { 
            Subtitles.Show(message[i]);
        }
        Destroy(gameObject);
    }
    public void Reverse() 
    {
        Controls.Invert(Axis.Forward);
        Controls.Invert(Axis.Side);
    }
    public void ActivateObjects(GameObject[] objs)
    {
        for (int i = 0; i < message.Length; i++)
        {
            objs[i].SetActive(true);
        }
    }
}
