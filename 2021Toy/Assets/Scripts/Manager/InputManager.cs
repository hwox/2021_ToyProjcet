using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    public GameObject clickEffect;

    Vector3 mousePos, targetPos, transPos;
    Dictionary<KeyCode, Action> keyDic;
    Vector3 rotPos;

    Camera mainCam;

    bool keyCoolTime;

    void Start()
    {
        clickEffect = GameObject.Find("ClickPosEffect"); // 우선 임시. 나중에 manager loading 순서 부분 정리 후에 연결
        clickEffect.SetActive(false);

        keyDic = new Dictionary<KeyCode, Action>
        {
            { KeyCode.A, KeyDown_A },
            { KeyCode.S, KeyDown_S },
            { KeyCode.D, KeyDown_D },
            { KeyCode.F, KeyDown_F },
            { KeyCode.K, KeyDonw_K },
            { KeyCode.T, KeyDown_T } 
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


    // 플레이어 이동은 마우스로
    void Update()
    {
        int layerMask = 1 << 10;

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                clickEffect.GetComponent<MapClickEffect>().getMousePos(hit.point);
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
        ObserverManager.Instance.dispatch(EGameSetting.INPUT_KEY_A);
    }
    private void KeyDown_S()
    {
        ObserverManager.Instance.dispatch(EGameSetting.INPUT_KEY_S);
    }
    private void KeyDown_D()
    {
        ObserverManager.Instance.dispatch(EGameSetting.INPUT_KEY_D);
    }
    private void KeyDown_F()
    {
        ObserverManager.Instance.dispatch(EGameSetting.INPUT_KEY_F);
    }

    private void KeyDonw_K()
    {
        Debug.Log("K is Skill Popup");
        PopupManager.Instance.show("PopupSkill");
    }

    private void KeyDown_T()
    {
        // 플레이어 타입 전환
        if (keyCoolTime)
            return;

        keyCoolTime = true;
        PlayerManager.Instance.playerTypeChange();

        Invoke("keyCoolTimeCheck", 1.0f);
    }

    private void keyCoolTimeCheck()
    {
        keyCoolTime = false;
    }
}
