using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IHashRecv
{
    void receiveCall(string key, Hashtable param);
}

public class ObserverManager : Singleton<ObserverManager>
{
    Dictionary<string, List<IHashRecv>> eventHashDic = new Dictionary<string, List<IHashRecv>>();


    public void registerEvent(string key, IHashRecv recv)
    {
        if(!eventHashDic.ContainsKey(key))
        {
            List<IHashRecv> hashList = new List<IHashRecv>();
            eventHashDic.Add(key, hashList);
        }

        eventHashDic[key].Add(recv);
    }


    public void unRegisterEvent(string key, IHashRecv recv)
    {
        if (!eventHashDic.ContainsKey(key))
            return;

        eventHashDic[key].Remove(recv);
    }

    public void removeAllHashEvent(string key)
    {
        if (!eventHashDic.ContainsKey(key))
            return;

        eventHashDic[key].Clear();
        eventHashDic.Remove(key);
    }

  
    // 입력된 key값의 이벤트를 호출
    public void dispatch(string key, Hashtable param = null)
    {
        if (!eventHashDic.ContainsKey(key)) return;

        var handler = eventHashDic[key];
        for (int i=0;i< handler.Count; ++i)
        {
            if(handler[i] != null)
                handler[i].receiveCall(key, param);
        }
    }
}
