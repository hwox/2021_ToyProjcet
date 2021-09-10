using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonUIManager : Singleton<CommonUIManager>, IHashRecv
{
    [SerializeField]
    public GameObject UICanvas;
    Button btnSetting;

    [SerializeField]
    Slider HPBar;


    public void init()
    {
        UICanvas = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UICanvas"));
        UICanvas.SetActive(false);

        HPBar = UICanvas.transform.Find("HP").GetComponent<Slider>();
        ObserverManager.Instance.registerEvent(EGameSetting.HP_PLUS, this);
        ObserverManager.Instance.registerEvent(EGameSetting.HP_MINUS, this);

        btnSetting = UICanvas.transform.GetChild(0).GetComponent<Button>();
        btnSetting.onClick.AddListener(onClickbtnSetting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void commonUICanvasActie(bool active)
    {
        UICanvas.SetActive(active);
    }

    void onClickbtnSetting()
    {
        PopupManager.Instance.show("PopupSetting");
    }

    public void receiveCall(string key, Hashtable param)
    {
        if (key == EGameSetting.HP_MINUS)
        {
            int damage = System.Convert.ToInt32(param["damage"]);
            HPBar.value -= (damage * 0.01f);
        }
        else if (key == EGameSetting.HP_PLUS)
        {
            int damage = System.Convert.ToInt32(param["damage"]);
            HPBar.value += (damage * 0.01f);
        }
    }
}
