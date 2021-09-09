using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.init();
        ObjectPoolManager.Instance.sceneChange("Play");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
