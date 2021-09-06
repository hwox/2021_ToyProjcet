using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGameSetting : MonoBehaviour
{
    static public float STANDARD_MOVE_SPEED = 10.0f;
    static public float STANDARD_ROT_SPEED  = 5.0f;

    // 카메라 세팅 view type
    static public int SHOULDER_VIEW = 0;
    static public int FPS_VIEW      = 1;
    static public int BACK_VIEW     = 2;


    // 플레이 로봇 타입 
    static public int ROBOT_RED     = 0;
    static public int ROBOT_YELLOW  = 1;
}
