using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : Singleton<PopupManager>
{
    bool isPopupActive { get; set; } // 현재 팝업이 띄워져있는 상태인지 확인

    // 게임 내에서 사용하는 팝업이 한정적이므로 팝업을 재사용한다.
    Dictionary<string, GameObject> popupList; // 팝업 재사용

    public void init()
    {
        popupList = new Dictionary<string, GameObject>();
    }
    
    public void show(string popupName)
    {
        if (isPopupActive)
            return;

        isPopupActive = true;
        
        if(popupList.ContainsKey(popupName))
        {
            popupList[popupName].SetActive(true);
            popupList[popupName].GetComponent<BasePopup>().init();
        }
        else
        {
            string popupPath = "Prefabs/Popup/" + popupName;
            GameObject obj = Instantiate(Resources.Load<GameObject>(popupPath));
            obj.transform.parent = CommonUIManager.Instance.UICanvas.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.SetActive(true);
            popupList[popupName] = obj;
            
            obj.GetComponent<BasePopup>().show();
        }
    }

    public void close(string popupName)
    {
        Debug.Log("PopupManager close");
        isPopupActive = false;
        popupList[popupName].SetActive(false);
    }
}
