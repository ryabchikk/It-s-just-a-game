using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public void GoToLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    public void GoToLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Forward(GameObject f)
    {
        Debug.Log(f.name);
    }
}
