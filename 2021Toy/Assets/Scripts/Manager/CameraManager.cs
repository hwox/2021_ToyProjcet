using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    // [SerializeField]
    // public List<Camera> cam = new List<Camera>();

    [SerializeField]
    Camera mainCam;

    [SerializeField]
    Transform mainCamTrans;

    [SerializeField]
    private int mainCamOffsetType;

    [SerializeField]
    private Transform playerTransform;

    readonly Vector3 cam1Offset = new Vector3(0f, 6f, -6f);
    readonly Vector3 cam2Offset = new Vector3(0f, 4f, -1.5f);

    Vector3 targetPos;

    const float posSmooth = 6f;
    const float attOffset = 3f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamOffsetType = 1;
        mainCam = Camera.main;
        mainCamTrans = mainCam.GetComponent<Transform>();
    }

    public void init()
    {
        GameObject obj = GameObject.Find("Player");
        if(obj != null)
        {
            playerTransform = obj.GetComponent<Transform>();
        }
        else
        {
            Debug.Log("Can't not find Player");
        }
    }

    private void FixedUpdate()
    {
        if(mainCamOffsetType == EGameSetting.SHOULDER_VIEW)
        {
            targetPos = playerTransform.transform.TransformPoint(cam1Offset);
        }
        else if(mainCamOffsetType == EGameSetting.FPS_VIEW)
        {
            targetPos = playerTransform.transform.TransformPoint(cam2Offset);
        }

        mainCamTrans.position = Vector3.Lerp(mainCamTrans.position, targetPos, Time.fixedDeltaTime * posSmooth);
        mainCamTrans.LookAt(playerTransform.position + attOffset * playerTransform.transform.forward);

        Debug.Log("dddd");
    }

    // UI 버튼 클릭 및 키 입력을 통한 카메라 offset change 
    public void camChange(int type)
    {
        mainCamOffsetType = type;
    }
}
