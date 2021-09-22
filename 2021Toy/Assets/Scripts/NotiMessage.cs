using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotiMessage : MonoBehaviour, IHashRecv
{
    public Text message;

    void Start()
    {
        this.gameObject.SetActive(false);
        ObserverManager.Instance.registerEvent(EGameSetting.NOTI_MESSAGE, this);
    }

    public void receiveCall(string key, Hashtable param)
    {
        if(key == EGameSetting.NOTI_MESSAGE)
        {
            this.gameObject.SetActive(true);
            if (param.ContainsKey("message"))
            {
                message.text = param["message"].ToString();
            }

            Invoke("activeFalse", 1.5f);
        }
    }

    void activeFalse()
    {
        this.gameObject.SetActive(false);
    }
}
