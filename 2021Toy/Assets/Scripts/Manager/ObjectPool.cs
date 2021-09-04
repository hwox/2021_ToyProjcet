using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    string nowScene;

    List<Object> poolObject;

    private void Awake()
    {
        nowScene = SceneCtrlManager.Instance.nowScene;
        makeObject(nowScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeObject(string sceneType)
    {
        switch(sceneType)
        {
            case "play":
                playSceneObject();
                break;
        }
    }

    void playSceneObject()
    {
        // 
    }
}
