using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Utility : MonoBehaviour
{
    [SerializeField] private string[] message;
    [SerializeField] private GameObject[] activateObjs;
    [SerializeField] private GameObject[] destroyObjs;
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

    public void ReverseJump()
    {
        Controls.NormalJump = !Controls.NormalJump;
    }

    public void ActivateObjects()
    {
        for (int i = 0; i < activateObjs.Length; i++)
        {
            activateObjs[i].SetActive(true);
        }
    }

    public void DestroyObjs() 
    {
        for (int i = 0; i < destroyObjs.Length; i++)
        {
            Destroy(activateObjs[i]);
        }
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
}
