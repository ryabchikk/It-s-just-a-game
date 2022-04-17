using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class ButtonManager : MonoBehaviour
{

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
    public void OpenPanel(GameObject obj)
    {
        obj.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClosePanel(GameObject obj)
    {
        obj.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenPausePanel(GameObject obj) 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            obj.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

