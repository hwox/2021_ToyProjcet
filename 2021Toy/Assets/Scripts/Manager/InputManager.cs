﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    Vector3 mousePos, targetPos, transPos;
    Dictionary<KeyCode, Action> keyDic;
    Vector3 rotPos;

    Camera mainCam;

    void Start()
    {
        keyDic = new Dictionary<KeyCode, Action>
        {
            { KeyCode.A, KeyDown_A },
            { KeyCode.S, KeyDown_S },
            { KeyCode.D, KeyDown_D }
        };
    }

    public void init()
    {
        mainCam = Camera.main;
        if(mainCam == null)
        {
            Debug.Log("mainCam is null");
        }
    }


    // 플레이어 이동은 마우스로 할 거임 
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                PlayerManager.Instance.playerMoveInput(hit.point);
            }
        }

        if (Input.anyKeyDown)
        {
            foreach (var dic in keyDic)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    dic.Value();
                }
            }
        }
    }

    private void KeyDown_A()
    {
        Debug.Log("A");
    }
    private void KeyDown_S()
    {
        Debug.Log("S");
    }
    private void KeyDown_D()
    {
        Debug.Log("D");
    }
}
