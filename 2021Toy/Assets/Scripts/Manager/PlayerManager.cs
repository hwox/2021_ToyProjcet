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
         // 나중에 PlayerManager 어디서 만들건지 보고 옮기기 
        // 애ㅑ초에 처음 시작할 때 플레이어를 생성해서 같이 넘겨주는것도 괜찮을 것 같음
        // 아니면 flow를 만들던가 
    }

    void Update()
    {
        
    }

    void onStartPlay()
    {
        player = GameObject.Find("Player");
        playerObj = player.GetComponent<PlayerObject>();
    }

    public void playerMoveInput(Vector3 pos)
    {
        onStartPlay();
        playerObj.playerMove(pos);
    }
}
