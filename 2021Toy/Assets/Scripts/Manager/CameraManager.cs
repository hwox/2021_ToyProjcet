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

    readonly Vector3 cam1Offset = new Vector3(0f, 3f, -1f);
    readonly Vector3 cam2Offset = new Vector3(0f, 4f, -1.5f);
    readonly Vector3 cam3Offset = new Vector3(0f, 6f, -6f);

    Vector3 targetPos;

    const float posSmooth = 10f;
    const float attOffset = 3f;

    bool camRotate; // 오른쪽 마우스 클릭으로 캠 회전 todo 

    // Start is called before the first frame update
    void Start()
    {
        mainCamOffsetType = 0;
        mainCam = Camera.main;
        mainCamTrans = mainCam.GetComponent<Transform>();
    }

    public void init(Transform pTrnas = null)
    {
        if(pTrnas != null)
        {
            playerTransform = pTrnas;
        }
        else
        {
            Debug.Log("Can't not find Player");
        }
    }


    private void LateUpdate()
    {
        if (mainCamOffsetType == EGameSetting.SHOULDER_VIEW)
        {
            targetPos = playerTransform.transform.TransformPoint(cam1Offset);
            mainCamTrans.position = Vector3.Lerp(mainCamTrans.position, targetPos, Time.fixedDeltaTime * posSmooth);
            mainCamTrans.LookAt(playerTransform.position + attOffset * playerTransform.transform.forward);
        }
        else if (mainCamOffsetType == EGameSetting.FPS_VIEW)
        {
            targetPos = playerTransform.transform.TransformPoint(cam2Offset);
            mainCamTrans.position = Vector3.Lerp(mainCamTrans.position, targetPos, Time.fixedDeltaTime * posSmooth);
            mainCamTrans.LookAt(playerTransform.position + attOffset * playerTransform.transform.forward);
        }
        else if (mainCamOffsetType == EGameSetting.BACK_VIEW)
        {
            targetPos = playerTransform.transform.TransformPoint(cam3Offset);
            mainCamTrans.position = Vector3.Lerp(mainCamTrans.position, targetPos, Time.fixedDeltaTime * posSmooth);
            mainCamTrans.LookAt(playerTransform.position + attOffset * playerTransform.transform.forward);
        }
    }


    // UI 버튼 클릭 및 키 입력을 통한 카메라 offset change 
    public void camChange(int type = 0)
    {
        mainCamOffsetType = type;
    }
}
