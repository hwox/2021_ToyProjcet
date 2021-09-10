using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonUIManager : Singleton<CommonUIManager>
{
    [SerializeField]
    public GameObject UICanvas;
    Button btnSetting;


    public void init()
    {
        UICanvas = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UICanvas"));
        UICanvas.SetActive(false);

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
}
