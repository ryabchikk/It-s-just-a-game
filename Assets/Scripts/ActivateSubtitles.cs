using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivateSubtitles : MonoBehaviour
{//�������� �����, ������ ��������
    [SerializeField] Text text;
    void OnTriggerEnter(Collider other)
    {
        text.text = "sdjf;asdlkjfpsofuijopfhdisoa;dfhidz;lfhkl";
    }
}
