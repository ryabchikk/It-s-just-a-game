using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class SettingMenu : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown;

    private Resolution[] _resolution;
    private void Start()
    {
        _resolution = Screen.resolutions;
        string[] strRes = new string[_resolution.Length];
        for (int i = 0; i < _resolution.Length; i++)
        {
            strRes[i] = _resolution[i].ToString();
        }
        _dropdown.AddOptions(strRes.ToList());

        Screen.SetResolution(_resolution[_resolution.Length - 1].width, _resolution[_resolution.Length - 1].height, true);
    }
    public void SetRes()
    {
        Screen.SetResolution(_resolution[_dropdown.value].width, _resolution[_dropdown.value].height, true);
    }

}