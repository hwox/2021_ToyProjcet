using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    const int POOL_OBJ_CNT = 10;
    string nowScene;

    [SerializeField]
    GameObject poolRoot;

    List<GameObject> originObj = new List<GameObject>(); // 프리팹들의 원본
    List<GameObject> poolObject = new List<GameObject>(); // 생성된 오브젝트들

    public enum poolType
    {
        start,
        bullet,
        last
    }


    public void init()
    {
        GameObject obj;
        string pathName;
        for (poolType p = poolType.start + 1; p < poolType.last; ++p)
        {
            // Resource 폴더의 Prefabs에서 해당 enum type의 오브젝트를 찾아서 origin List에 넣기 
            pathName = "Prefabs/" + p.ToString();
            obj = Resources.Load<GameObject>(pathName);
            if (obj is null)
            {
                Debug.Log("obj is null");
            }
            originObj.Add(obj);
        }
    }

    public void sceneChange(string sceneType)
    {
        poolRoot = GameObject.Find("PoolRoot");
        nowScene = sceneType;
        makeObject(nowScene);
    }

    public void makeObject(string sceneType)
    {
        switch(sceneType)
        {
            case "Play":
                playSceneObject();
                break;
            default:
                Debug.Log("[ObjectPool] -> sceneType is Null");
                break;
        }
    }

    private GameObject CreatePoolObject(int idx)
    {
        var obj = Instantiate(originObj[idx], poolRoot.transform);
        obj.SetActive(false);
        return obj;
    }

    void playSceneObject()
    {
        for(int i=0;i<originObj.Count; ++i)
        {
            if(originObj == null)
                continue;

            for(int j=0;j<POOL_OBJ_CNT;++j)
            {
                poolObject.Add(CreatePoolObject(i));
            }
        }
    }

    public GameObject pop(poolType type)
    {
        for(int i=0;i<POOL_OBJ_CNT;++i)
        {
            if(poolObject[i+(POOL_OBJ_CNT)*((int)type-1)].active == true)
            {
                continue;
            }
            else
            {
                return poolObject[i + (POOL_OBJ_CNT) * ((int)type - 1)];
            }
        }

        return null;
    }
}
