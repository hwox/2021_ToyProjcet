using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    protected int hp;
    protected int state { get; set; }
    protected float moveSpeed;
    protected float rotSpeed; 

    protected bool isNowUseSkill { get; set; }

    protected bool isMoveEnable
    {
        get
        {
            if (isNowUseSkill)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    void Awake()
    {
        moveSpeed = EGameSetting.STANDARD_MOVE_SPEED;
        rotSpeed = EGameSetting.STANDARD_ROT_SPEED;
    }

    virtual public void die()
    {

    }

    public void moveSpeedChange(float num)
    {
        moveSpeed += num;
    }
}
