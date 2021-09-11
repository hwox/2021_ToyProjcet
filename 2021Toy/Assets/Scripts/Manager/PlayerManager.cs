using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerType
{
    red,
    yellow,
    blue,
    last
}

public class PlayerManager : Singleton<PlayerManager>
{
    int state;
    int type;

    Camera MainCamera;

    [SerializeField]
    GameObject player;
    PlayerObject playerObj;

    public bool isUIOpen { get; set; }

    public void init()
    {
        player = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        playerObj = player.GetComponent<PlayerObject>();

        if(player != null)
        {
            CameraManager.Instance.init(player.transform);
        }
        else
        {
            Debug.Log("Player is Null -> CameraManager can't init");
        }
    }

    void Start()
    {
        
    }

    public void playerMoveInput(Vector3 transPos)
    {
        if (isUIOpen)
            return;

        playerObj.playerMove(transPos);
    }

    public int getPlayerNowType()
    {
        return type;
    }

    public void playerTypeChange()
    {
        type += 1;

        if(type >= (int)playerType.last)
        {
            type = 0;
        }

        playerObj.playRobotTypeChange(type);
        ObserverManager.Instance.dispatch(EGameSetting.PLAYER_TYPE_CHANGE);
    }
}
