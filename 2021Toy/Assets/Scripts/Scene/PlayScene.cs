using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScene : MonoBehaviour
{
    public Button camOffset1;
    public Button camOffset2;
    public Button camOffset3;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.init();
        ObjectPoolManager.Instance.sceneChange("Play");

        camOffset1.onClick.AddListener(()=>CameraManager.Instance.camChange(0));
        camOffset2.onClick.AddListener(() => CameraManager.Instance.camChange(1));
        camOffset3.onClick.AddListener(() => CameraManager.Instance.camChange(2));

        CommonUIManager.Instance.commonUICanvasActie(true);
    }

    private void OnDestroy()
    {
        camOffset1.onClick.RemoveAllListeners();
        camOffset2.onClick.RemoveAllListeners();
        camOffset3.onClick.RemoveAllListeners();
    }

}
