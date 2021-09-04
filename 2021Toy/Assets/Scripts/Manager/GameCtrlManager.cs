using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrlManager : Singleton<GameCtrlManager>
{

    public void init()
    {
        // 매니저 생성 
        SceneCtrlManager.Instance.init();
        SoundManager.Instance.init();
        DataManager.Instance.init();
        PopupManager.Instance.init();
        PlayerManager.Instance.init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
