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
        playerObj.playerMove(transPos);
    }
}
