using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    int state;

    int type; // 

    Camera MainCamera;

    [SerializeField]
    GameObject player;
    PlayerObject playerObj;

    public void init()
    {
    }

    void Start()
    {
        onStartPlay(); // for test
    }

    void Update()
    {
        
    }

    void onStartPlay()
    {
        player = GameObject.Find("Player");
        playerObj = player.GetComponent<PlayerObject>();
    }

    // UI 버튼 클릭 및 키 입력을 통한 카메라 offset change 
    public void camAngleChange()
    {

    }

    public void playerMoveInput(Vector3 pos)
    {
        onStartPlay();
        playerObj.playerMove(pos);
    }
}
