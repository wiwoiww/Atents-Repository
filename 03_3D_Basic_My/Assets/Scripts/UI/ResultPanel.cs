using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    Button button;
    

    private void Awake()
    {
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(ButtonTest2);
    }

    private void ButtonTest2()
    {
        Debug.Log("버튼클릭2");
    }

    public void ButtonTest1()
    {
        Debug.Log("버튼클릭");
    }

}
